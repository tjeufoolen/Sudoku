using DP1_Sudoku.BusinessLogic.Extensions;
using DP1_Sudoku.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic
{
    public class Board : IBoard
    {
        public ISolveStrategy? SolveStrategy { get; set; }

        public Cell[,]? Cells { get; set; }
        public IList<GroupComposite> SubGroups { get; set; } = new List<GroupComposite>();
        public IList<GroupComposite> HorizontalGroups { get; set; } = new List<GroupComposite>();
        public IList<GroupComposite> VerticalGroups { get; set; } = new List<GroupComposite>();

        public int MaxValidCellValue { get => (Cells != null) ? Cells.Cast<Cell>().Max(c => c.MaxValidValue) : 0; }

        public async Task Solve(Task onCellValueUpdate)
        {
            if (SolveStrategy != null)
            {
                await SolveStrategy.SolveBoard(this, onCellValueUpdate);
            }
        }

        public void Accept(IVisitor visitor)
        {
            throw new NotImplementedException();
        }

        public bool Validate()
        {
            return ValidateGroups();
        }

        /// <summary>
        /// Checks if there are any conflicting cells on the board, ignores empty cells
        /// </summary>
        /// <returns></returns>
        public bool IsBoardCorrect()
        {
            VerifyBoard();
            if (Cells == null) return true;

            bool boardIsValid = true;
            for (int row = 0; row < Cells.GetLength(0); row++)
            {
                for (int column = 0; column < Cells.GetLength(1); column++)
                {
                    if (!(Cells[row, column].IsValid)) boardIsValid = false;
                }
            }

            return boardIsValid;
        }

        /// <summary>
        /// Calls the validate method on each field, which in turn converts any currently invalid cell to invalid state.
        /// </summary>
        public void VerifyBoard()
        {
            SubGroups.ForEach(subgroup => subgroup.Validate());
            HorizontalGroups.ForEach(horizontalGroup => horizontalGroup.Validate());
            VerticalGroups.ForEach(verticalGroup => verticalGroup.Validate());
        }

        /// <summary>
        /// More efficient version of VerifyBoard, which stops at the first occurence of an invalid group
        /// </summary>
        /// <returns></returns>
        public virtual bool ValidateGroups()
        {
            return
                SubGroups.All(subgroup => subgroup.Validate()) &&
                HorizontalGroups.All(horizontalGroup => horizontalGroup.Validate()) &&
                VerticalGroups.All(verticalGroup => verticalGroup.Validate());
        }

        public bool IsEqualTo(IGridComponent component)
        {
            if (component == null || component is not Board otherAsBoard) return false;
            return otherAsBoard == this;
        }
    }
}
