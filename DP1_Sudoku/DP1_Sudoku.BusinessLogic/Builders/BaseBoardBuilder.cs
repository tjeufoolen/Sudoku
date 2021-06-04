using DP1_Sudoku.BusinessLogic.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DP1_Sudoku.BusinessLogic.Builders
{
    public abstract class BaseBoardBuilder : IBoardBuilder
    {
        public IBoard Board { get; private set; } = new Board();

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

        protected virtual Cell[,] CreateCells(IList<string> lines)
        {
            Cell[,] cellRows = new Cell[lines.Count, lines.Max(x => x.Length)];

            for (int rowIdx = 0; rowIdx < lines.Count; rowIdx++)
            {
                for (int charIdx = 0; charIdx < lines[rowIdx].Length; charIdx++)
                {
                    cellRows[rowIdx, charIdx] = new Cell(lines[rowIdx][charIdx]);
                }
            }

            return cellRows;
        }

        protected virtual void SetCellNeighbours(Cell[,] cellRows)
        {
            for (int rowIdx = 0; rowIdx < cellRows.Rank; rowIdx++)
            {
                for (int charIdx = 0; charIdx < cellRows.GetLength(rowIdx); charIdx++)
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
