using DP1_Sudoku.BusinessLogic.Extensions;
using DP1_Sudoku.BusinessLogic.States.CellStates;
using System.Collections.Generic;

namespace DP1_Sudoku.BusinessLogic.Builders
{
    public class SamuraiBoardBuilder : NormalBoardBuilder
    {
        private int _spaceBetweenSubSudokus = 3;

        private Cell[,]? _sudoku = null;
        private Cell[,]? _topLeftSubSudoku = null;
        private Cell[,]? _topRightSubSudoku = null;
        private Cell[,]? _bottomLeftSubSudoku = null;
        private Cell[,]? _bottomRightSubSudoku = null;
        private Cell[,]? _centerSubSudoku = null;

        public SamuraiBoardBuilder()
        {
            _rowLength = 9;
            _columnLength = 9;
            _subgroupHeight = 3;
            _subgroupWidth = 3;
        }

        public override void Reset()
        {
            base.Reset();

            _sudoku = null;
            _topLeftSubSudoku = null;
            _topRightSubSudoku = null;
            _bottomLeftSubSudoku = null;
            _bottomRightSubSudoku = null;
            _centerSubSudoku = null;
        }

        protected override void BuildColumnGroups()
        {
            if (_sudoku == null || _topLeftSubSudoku == null || _topRightSubSudoku == null ||
                _bottomLeftSubSudoku == null || _bottomRightSubSudoku == null || _centerSubSudoku == null)
                return;

            List<Cell[,]> sudokus = new()
            {
                _topLeftSubSudoku,
                _topRightSubSudoku,
                _bottomLeftSubSudoku,
                _bottomRightSubSudoku,
                _centerSubSudoku,
            };

            foreach (Cell[,] subSudoku in sudokus)
            {
                for (int colIdx = 0; colIdx < subSudoku.GetLength(1); colIdx++)
                {
                    var group = new GroupComposite();
                    var rowCells = GetColumn(subSudoku, colIdx);

                    group.Children.AddRange(rowCells);

                    Board.VerticalGroups.Add(group);
                }
            }
        }

        protected override void BuildRowGroups()
        {
            if (_sudoku == null || _topLeftSubSudoku == null || _topRightSubSudoku == null ||
                _bottomLeftSubSudoku == null || _bottomRightSubSudoku == null || _centerSubSudoku == null)
                return;

            List<Cell[,]> sudokus = new()
            {
                _topLeftSubSudoku,
                _topRightSubSudoku,
                _bottomLeftSubSudoku,
                _bottomRightSubSudoku,
                _centerSubSudoku,
            };

            foreach (Cell[,] subSudoku in sudokus)
            {
                for (int rowIdx = 0; rowIdx < subSudoku.GetLength(0); rowIdx++)
                {
                    var group = new GroupComposite();
                    var rowCells = GetRow(subSudoku, rowIdx);

                    group.Children.AddRange(rowCells);

                    Board.HorizontalGroups.Add(group);
                }
            }
        }

        protected override void BuildSubgroups()
        {
            if (_topLeftSubSudoku == null || _topRightSubSudoku == null || _bottomLeftSubSudoku == null ||
                _bottomRightSubSudoku == null || _centerSubSudoku == null || Board == null || Board.Cells == null)
                return;

            List<OffsetData> offsets = new()
            {
                GetTopLeftSudokuOffset()!,
                GetTopRightSudokuOffset()!,
                GetBottomLeftSudokuOffset()!,
                GetBottomRightSudokuOffset()!,
                GetCenterSudokuOffset()!
            };

            foreach (var sudokuOffset in offsets)
            {
                int horizontalSubGroupCount = _rowLength / _subgroupWidth;
                int verticalSubGroupCount = _columnLength / _subgroupHeight;

                // Determine the amount of horizontal groups
                for (int horizontalGroup = 0; horizontalGroup < horizontalSubGroupCount; horizontalGroup++)
                {
                    // Determine the amount of vertical groups
                    for (int verticalGroup = 0; verticalGroup < verticalSubGroupCount; verticalGroup++)
                    {
                        var group = new GroupComposite();

                        // Convert current horizontal group to minimum and maximum coordinates
                        int lowestHorizontalIndex = horizontalGroup * _subgroupWidth;
                        int highestHorizontalIndex = lowestHorizontalIndex + _subgroupWidth;

                        // Convert current vertical group to minimum and maximum coordinates
                        int lowestVerticalIndex = verticalGroup * _subgroupHeight;
                        int highestVerticalIndex = lowestVerticalIndex + _subgroupHeight;

                        // Loop over all the cells in the map and add them to the group
                        for (int horizontalIdx = lowestHorizontalIndex; horizontalIdx < highestHorizontalIndex; horizontalIdx++)
                        {
                            for (int verticalIdx = lowestVerticalIndex; verticalIdx < highestVerticalIndex; verticalIdx++)
                            {
                                group.Children.Add(Board.Cells[verticalIdx + sudokuOffset.RowOffset, horizontalIdx + sudokuOffset.ColumnOffset]);
                            }
                        }

                        Board.SubGroups.Add(group);
                    }
                }
            }
        }

        protected override Cell[,] CreateCells(IList<string> lines)
        {
            _sudoku = new Cell[_columnLength * 2 + _spaceBetweenSubSudokus, _rowLength * 2 + _spaceBetweenSubSudokus];

            // Build all subsudokus separate
            _topLeftSubSudoku = base.CreateCells(new List<string> { lines[0] });
            _topRightSubSudoku = base.CreateCells(new List<string> { lines[1] });
            _bottomLeftSubSudoku = base.CreateCells(new List<string> { lines[3] });
            _bottomRightSubSudoku = base.CreateCells(new List<string> { lines[4] });
            _centerSubSudoku = base.CreateCells(new List<string> { lines[2] });

            SetSubSudoku(GetTopLeftSudokuOffset()!);
            SetSubSudoku(GetTopRightSudokuOffset()!);
            SetSubSudoku(GetBottomLeftSudokuOffset()!);
            SetSubSudoku(GetBottomRightSudokuOffset()!);

            SetCenterSudoku();

            // Must be at the end, because it checks which cells are still remaining and null
            SetSpaceBetweenSubSudoku();

            return _sudoku;
        }

        private void SetSpaceBetweenSubSudoku()
        {
            if (_sudoku == null) return;

            for (int rowIdx = 0; rowIdx < _sudoku.GetLength(0); rowIdx++)
            {
                for (int colIdx = 0; colIdx < _sudoku.GetLength(1); colIdx++)
                {
                    if (_sudoku[rowIdx, colIdx] == null)
                    {
                        Cell cell = new Cell(0);
                        cell.SetState(new BlockedCellState(cell));
                        _sudoku[rowIdx, colIdx] = cell;
                    }
                }
            }
        }

        private void SetSubSudoku(OffsetData offsetData) => SetSubSudoku(offsetData.Sudoku, offsetData.RowOffset, offsetData.ColumnOffset);

        private void SetSubSudoku(Cell[,]? subSudoku, int rowOffset, int colOffset)
        {
            if (_sudoku == null || subSudoku == null) return;

            for (int rowIdx = 0; rowIdx < subSudoku.GetLength(0); rowIdx++)
            {
                for (int colIdx = 0; colIdx < subSudoku.GetLength(1); colIdx++)
                {
                    if (_sudoku[rowIdx + rowOffset, colIdx + colOffset] == null)
                        _sudoku[rowIdx + rowOffset, colIdx + colOffset] = subSudoku[rowIdx, colIdx];
                }
            }
        }

        private OffsetData? GetTopLeftSudokuOffset() => _topLeftSubSudoku != null ? new(_topLeftSubSudoku, 0, 0) : null;
        private OffsetData? GetTopRightSudokuOffset() => _topRightSubSudoku != null ? new(_topRightSubSudoku, 0, _rowLength + _spaceBetweenSubSudokus) : null;
        private OffsetData? GetBottomLeftSudokuOffset() => _bottomLeftSubSudoku != null ? new(_bottomLeftSubSudoku, _columnLength + _spaceBetweenSubSudokus, 0) : null;
        private OffsetData? GetBottomRightSudokuOffset() => _bottomRightSubSudoku != null ? new(_bottomRightSubSudoku, _columnLength + _spaceBetweenSubSudokus, _rowLength + _spaceBetweenSubSudokus) : null;
        private OffsetData? GetCenterSudokuOffset() => _centerSubSudoku != null ? new(_centerSubSudoku, _subgroupWidth * 2, _subgroupHeight * 2) : null;

        private void SetCenterSudoku()
        {
            if (_topLeftSubSudoku == null || _topRightSubSudoku == null || _bottomLeftSubSudoku == null || _bottomRightSubSudoku == null || _centerSubSudoku == null) return;

            // Reuse corners
            List<OffsetData> offsets = new()
            {
                new(_topLeftSubSudoku, 0, 0),
                new(_topRightSubSudoku, 0, 6),
                new(_bottomLeftSubSudoku, 6, 0),
                new(_bottomRightSubSudoku, 6, 6)
            };

            foreach (var cornerData in offsets)
            {
                for (int rowIdx = cornerData.RowOffset; rowIdx < _subgroupHeight + cornerData.RowOffset; rowIdx++)
                {
                    for (int colIdx = cornerData.ColumnOffset; colIdx < _subgroupWidth + cornerData.ColumnOffset; colIdx++)
                    {
                        _centerSubSudoku[rowIdx, colIdx] = cornerData.Sudoku[rowIdx, colIdx];
                    }
                }
            }

            SetSubSudoku(GetCenterSudokuOffset()!);
        }

        private class OffsetData
        {
            public Cell[,] Sudoku { get; set; }
            public int RowOffset { get; set; }
            public int ColumnOffset { get; set; }

            public OffsetData(Cell[,] sudoku, int rowOffset, int colOffset)
            {
                this.Sudoku = sudoku;
                this.RowOffset = rowOffset;
                this.ColumnOffset = colOffset;
            }
        };
    }
}