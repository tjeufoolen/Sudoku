using System.Collections.Generic;
using System.Linq;
using DP1_Sudoku.BusinessLogic.Extensions;

namespace DP1_Sudoku.BusinessLogic.Builders
{
    public abstract class NormalBoardBuilder : BaseBoardBuilder
    {
        protected int RowLength { get; set; }
        protected int ColumnLength { get; set; }
        protected int SubgroupHeight { get; set; }
        protected int SubgroupWidth { get; set; }

        public override void BuildGroups(IList<string> lines)
        {
            BuildRowGroups(lines);
            BuildColumnGroups(lines);
            BuildSubgroups(lines);
        }

        protected void BuildRowGroups(IList<string> lines)
        {
            for (int row = 0; row < Board.Cells?.GetLength(0); row++)
            {
                var group = new GroupComposite();
                var rowCells = GetRow(Board.Cells, row);

                group.Children.AddRange(rowCells);

                Board.Groups.Add(group);
            }
        }

        protected void BuildColumnGroups(IList<string> lines)
        {
            for (int column = 0; column < Board.Cells?.GetLength(1); column++)
            {
                var group = new GroupComposite();
                var columnCells = GetColumn(Board.Cells, column);

                group.Children.AddRange(columnCells);

                Board.Groups.Add(group);
            }
        }

        protected void BuildSubgroups(IList<string> lines)
        {
            if (Board.Cells == null) return;

            int horizontalSubGroupCount = RowLength / SubgroupWidth;
            int verticalSubGroupCount = ColumnLength / SubgroupHeight;

            // Determine the amount of horizontal groups
            for (int horizontalGroup = 0; horizontalGroup < horizontalSubGroupCount; horizontalGroup++)
            {
                // Determine the amount of vertical groups
                for(int verticalGroup = 0; verticalGroup < verticalSubGroupCount; verticalGroup++)
                {
                    var group = new GroupComposite();

                    // Convert current horizontal group to minimum and maximum coordinates
                    int lowestHorizontalIndex = horizontalGroup * SubgroupWidth;
                    int highestHorizontalIndex = lowestHorizontalIndex + SubgroupWidth;

                    // Convert current vertical group to minimum and maximum coordinates
                    int lowestVerticalIndex = verticalGroup * SubgroupHeight;
                    int highestVerticalIndex = lowestVerticalIndex + SubgroupHeight;

                    // Loop over all the cells in the map and add them to the group
                    for (int horizontalIdx = lowestHorizontalIndex; horizontalIdx < highestHorizontalIndex; horizontalIdx++)
                    {
                        for (int verticalIdx = lowestVerticalIndex; verticalIdx < highestVerticalIndex; verticalIdx++)
                        {
                            group.Children.Add(Board.Cells[horizontalIdx, verticalIdx]);
                        }
                    }

                    Board.Groups.Add(group);
                }
            }
        }

        protected override Cell[,] CreateCells(IList<string> lines)
        {
            Cell[,] cellRows = new Cell[RowLength, RowLength];
            string[]? rows = lines[0].SplitInParts(RowLength).ToArray();

            for (int rowIdx = 0; rowIdx < rows?.Length; rowIdx++)
            {
                for (int charIdx = 0; charIdx < rows[rowIdx].Length; charIdx++)
                {
                    cellRows[rowIdx, charIdx] = new Cell(rows[rowIdx][charIdx]);
                }
            }

            return cellRows;
        }

        #region Helpers
        protected static Cell[] GetRow(Cell[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }

        protected static Cell[] GetColumn(Cell[,] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                    .Select(x => matrix[x, columnNumber])
                    .ToArray();
        }
        #endregion Helpers
    }
}
