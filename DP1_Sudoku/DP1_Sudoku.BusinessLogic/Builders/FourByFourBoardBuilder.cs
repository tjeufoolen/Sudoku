namespace DP1_Sudoku.BusinessLogic.Builders
{
    public class FourByFourBoardBuilder : NormalBoardBuilder
    {
        public FourByFourBoardBuilder()
        {
            _rowLength = 4;
            _columnLength = 4;
            _subgroupHeight = 2;
            _subgroupWidth = 2;
        }
    }
}
