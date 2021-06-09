namespace DP1_Sudoku.BusinessLogic.Builders
{
    public class SixBySixBoardBuilder : NormalBoardBuilder
    {
        public SixBySixBoardBuilder()
        {
            _rowLength = 6;
            _columnLength = 6;
            _subgroupHeight = 2;
            _subgroupWidth = 3;
            _maxValidCellValue = 6;
        }
    }
}
