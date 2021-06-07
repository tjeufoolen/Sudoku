using DP1_Sudoku.BusinessLogic.States.CellStates;
using System.Collections.Generic;

namespace DP1_Sudoku.BusinessLogic.Builders
{
    public class SamuraiBoardBuilder : NormalBoardBuilder
    {
        private int _spaceBetweenSubSudokus = 3;

        public SamuraiBoardBuilder()
        {
            _rowLength = 9;
            _columnLength = 9;
            _subgroupHeight = 3;
            _subgroupWidth = 3;
        }

        protected override void BuildColumnGroups()
        {
            //throw new NotImplementedException();
        }

        protected override void BuildRowGroups()
        {
            //throw new NotImplementedException();
        }

        protected override void BuildSubgroups()
        {
            //throw new NotImplementedException();
        }

        protected override Cell[,] CreateCells(IList<string> lines)
        {
            Cell[,] cellRows = new Cell[_columnLength * 2 + _spaceBetweenSubSudokus, _rowLength * 2 + _spaceBetweenSubSudokus];

            // Build all subsudokus separate
            Cell[,] topLeft = base.CreateCells(new List<string> { lines[0] });
            Cell[,] topRight = base.CreateCells(new List<string> { lines[1] });
            Cell[,] center = base.CreateCells(new List<string> { lines[2] });
            Cell[,] bottomLeft = base.CreateCells(new List<string> { lines[3] });
            Cell[,] bottomRight = base.CreateCells(new List<string> { lines[4] });

            SetTopLeftSudoku(cellRows, topLeft);
            SetTopRightSudoku(cellRows, topRight);
            SetBottomLeftSudoku(cellRows, bottomLeft);
            SetBottomRightSudoku(cellRows, bottomRight);
            SetCenterSudoku(cellRows, center);

            // Must be at the end, because it checks which cells are still remaining and null
            SetSpaceBetweenSubSudoku(cellRows);

            return cellRows;
        }

        private void SetSpaceBetweenSubSudoku(Cell[,] cellRows)
        {
            for (int rowIdx = 0; rowIdx < cellRows.GetLength(0); rowIdx++)
            {
                for (int colIdx = 0; colIdx < cellRows.GetLength(1); colIdx++)
                {
                    if (cellRows[rowIdx, colIdx] == null)
                    {
                        Cell cell = new Cell(0);
                        cell.SetState(new BlockedCellState(cell));
                        cellRows[rowIdx, colIdx] = cell;
                    }
                }
            }
        }

        private void SetSubSudoku(Cell[,] cellRows, Cell[,] topRight, int rowOffset, int colOffset)
        {
            for (int rowIdx = 0; rowIdx < topRight.GetLength(0); rowIdx++)
            {
                for (int colIdx = 0; colIdx < topRight.GetLength(1); colIdx++)
                {
                    cellRows[rowIdx + rowOffset, colIdx + colOffset] = topRight[rowIdx, colIdx];
                }
            }
        }

        private void SetTopLeftSudoku(Cell[,] cellRows, Cell[,] topRight) => SetSubSudoku(cellRows, topRight, 0, 0);
        private void SetTopRightSudoku(Cell[,] cellRows, Cell[,] topRight) => SetSubSudoku(cellRows, topRight, 0, _rowLength + _spaceBetweenSubSudokus);
        private void SetBottomLeftSudoku(Cell[,] cellRows, Cell[,] topRight) => SetSubSudoku(cellRows, topRight, _columnLength + _spaceBetweenSubSudokus, 0);
        private void SetBottomRightSudoku(Cell[,] cellRows, Cell[,] topRight) => SetSubSudoku(cellRows, topRight, _columnLength + _spaceBetweenSubSudokus, _rowLength + _spaceBetweenSubSudokus);
        private void SetCenterSudoku(Cell[,] cellRows, Cell[,] center) => SetSubSudoku(cellRows, center, _subgroupWidth * 2, _subgroupHeight * 2);
    }
}
