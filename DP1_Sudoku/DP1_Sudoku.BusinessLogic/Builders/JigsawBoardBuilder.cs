using System.Collections.Generic;

namespace DP1_Sudoku.BusinessLogic.Builders
{
    public class JigsawBoardBuilder : BaseBoardBuilder
    {
        private readonly SortedList<int, GroupComposite> _subGroupLinks = new();

        protected int _rowLength = 9;
        protected int _columnLength = 9;

        public override void Reset()
        {
            base.Reset();

            _subGroupLinks.Clear();
        }

        protected override Cell[,] CreateCells(IList<string> lines)
        {
            Cell[,] cellRows = new Cell[_columnLength, _rowLength];

            // Split lines list so that we have a list with only field parts
            // Example field part: "8J1"
            List<string> choppedLines = new(lines[0].Split("="));
            choppedLines.RemoveAt(0); // Removes 'SumoCueV1' prefix

            int rowIdx = 0; // Keeps track of the row index of where a cell should be in a twodimensional array
            int columnIdx = 0; // Keeps track of the column index of where a cell should be in a twodimensional array
            foreach (var field in choppedLines)
            {
                string[] fieldParts = field.Split("J");

                // Create cell with value and add to array
                if (int.TryParse(fieldParts[0], out int fieldValue))
                {
                    Cell cell = new(fieldValue);
                    cellRows[columnIdx, rowIdx] = cell;

                    // Link the cell to a group composite so that we can easily set subgroups later
                    if (int.TryParse(fieldParts[1], out int fieldSubgroupIdx))
                    {
                        if (!_subGroupLinks.ContainsKey(fieldSubgroupIdx))
                        {
                            _subGroupLinks.Add(fieldSubgroupIdx, new GroupComposite());
                        }

                        var subgroup = _subGroupLinks[fieldSubgroupIdx];
                        subgroup.Children.Add(cell);
                        cell.ValidationGroups.Add(subgroup);
                    }
                }

                // Update row and column indexes for the next cell
                if (columnIdx < _columnLength - 1) columnIdx++;
                else
                {
                    columnIdx = 0;
                    rowIdx++;
                }
            }

            return cellRows;
        }

        protected override void BuildSubgroups()
        {
            foreach (KeyValuePair<int, GroupComposite> link in _subGroupLinks)
            {
                Board.SubGroups.Add(link.Value);
            }
        }
    }


}
