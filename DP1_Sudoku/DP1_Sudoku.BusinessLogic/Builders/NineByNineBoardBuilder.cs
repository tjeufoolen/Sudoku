namespace DP1_Sudoku.BusinessLogic.Builders
{
    public class NineByNineBoardBuilder : NormalBoardBuilder
    {
        public NineByNineBoardBuilder()
        {
            RowLength = 9;
            ColumnLength = 9;
            SubgroupHeight = 3;
            SubgroupWidth = 3;
        }
    }
}
