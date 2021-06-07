namespace DP1_Sudoku.BusinessLogic.Builders
{
    public class SixBySixBoardBuilder : NormalBoardBuilder
    {
        public SixBySixBoardBuilder()
        {
            RowLength = 6;
            ColumnLength = 6;
            SubgroupHeight = 2;
            SubgroupWidth = 3;
        }
    }
}
