using DP1_Sudoku.BusinessLogic.Extensions;
using DP1_Sudoku.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DP1_Sudoku.BusinessLogic
{
    public class Board : IBoard
    {
        public ISolveStrategy? SolveStrategy { private get; set; }

        public Cell[,]? Cells { get; set; }
        public IList<GroupComposite> SubGroups { get; set; } = new List<GroupComposite>();
        public IList<GroupComposite> HorizontalGroups { get; set; } = new List<GroupComposite>();
        public IList<GroupComposite> VerticalGroups { get; set; } = new List<GroupComposite>();

        public void Solve()
        {
            SolveStrategy?.SolveBoard(this);
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
