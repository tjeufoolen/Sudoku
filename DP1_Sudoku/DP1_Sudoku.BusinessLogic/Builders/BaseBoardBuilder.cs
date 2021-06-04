using DP1_Sudoku.BusinessLogic.Interfaces;
using System.Collections.Generic;

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

                    // Check for cell above current cell
                    if (rowIdx - 1 >= 0)
                        current.Top = cellRows[rowIdx - 1, charIdx];

                    // Check for cell below current cell
                    if (rowIdx + 1 <= amountOfRows)
                        current.Bottom = cellRows[rowIdx + 1, charIdx];

                    // Check for cell left of current cell
                    if (charIdx - 1 >= 0)
                        current.Left = cellRows[rowIdx, charIdx - 1];

                    // Check for cell right of current cell
                    if (charIdx + 1 <= maxRowLength)
                        current.Right = cellRows[rowIdx, charIdx + 1];
                }
            }
        }
    }
}
