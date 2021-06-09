namespace DP1_Sudoku.BusinessLogic.Builders
{
    public class NineByNineBoardBuilder : NormalBoardBuilder
    {
        public NineByNineBoardBuilder()
        {
            _rowLength = 9;
            _columnLength = 9;
            _subgroupHeight = 3;
            _subgroupWidth = 3;
        }
    }
}
