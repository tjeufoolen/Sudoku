using DP1_Sudoku.BusinessLogic.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace DP1_Sudoku.BusinessLogic.Builders
{
    public abstract class NormalBoardBuilder : BaseBoardBuilder
    {
        protected int _rowLength;
        protected int _columnLength;
        protected int _subgroupHeight;
        protected int _subgroupWidth;
        protected int _maxValidCellValue = 9;

        protected override void BuildSubgroups()
        {
            BuildSubgroups(0, 0);
        }

        protected virtual void BuildSubgroups(int rowOffset, int colOffset)
        {
            if (Board.Cells == null) return;

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
                            group.Children.Add(Board.Cells[verticalIdx + rowOffset, horizontalIdx + colOffset]);
                        }
                    }

                    Board.SubGroups.Add(group);
                }
            }
        }

        protected override Cell[,] CreateCells(IList<string> lines)
        {
            Cell[,] cellRows = new Cell[_columnLength, _rowLength];
            string[]? rows = lines[0].SplitInParts(_rowLength).ToArray();

            for (int rowIdx = 0; rowIdx < rows?.Length; rowIdx++)
            {
                for (int charIdx = 0; charIdx < rows[rowIdx].Length; charIdx++)
                {
                    // Reference: https://stackoverflow.com/questions/45030/how-to-parse-a-string-into-a-nullable-int
                    int result = int.TryParse(rows[rowIdx][charIdx].ToString(), out var value) ? value : 0;
                    cellRows[rowIdx, charIdx] = new Cell(result, _maxValidCellValue);
                }
            }

            return cellRows;
        }
    }
}
