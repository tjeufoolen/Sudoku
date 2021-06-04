using DP1_Sudoku.BusinessLogic.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DP1_Sudoku.BusinessLogic.Builders
{
    public abstract class BaseBoardBuilder : IBoardBuilder
    {
        public IBoard Board { get; protected set; } = new Board();

        public void Reset()
        {
            Board = new Board();
        }

        public void BuildCells(IList<string> lines)
        {
            var cells = CreateCells(lines);
            SetCellNeighbours(cells);

            Board.Cells = cells;
        }

        public abstract void BuildGroups(IList<string> lines);

        protected abstract Cell[,] CreateCells(IList<string> lines);

        protected virtual void SetCellNeighbours(Cell[,] cellRows)
        {
            int amountOfRows = cellRows.GetLength(0);
            int maxRowLength = cellRows.GetLength(1);

            for (int rowIdx = 0; rowIdx < amountOfRows; rowIdx++)
            {
                for (int charIdx = 0; charIdx < maxRowLength; charIdx++)
                {
                    Cell current = cellRows[rowIdx, charIdx];

                    Cell? above = cellRows[rowIdx - 1, charIdx] ?? null;
                    Cell? beneath = cellRows[rowIdx + 1, charIdx] ?? null;
                    Cell? left = cellRows[rowIdx, charIdx - 1] ?? null;
                    Cell? right = cellRows[rowIdx, charIdx + 1] ?? null;

                    current.Top = above;
                    current.Bottom = beneath;
                    current.Left = left;
                    current.Right = right;
                }
            }
        }
    }
}
