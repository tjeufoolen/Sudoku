using System.Collections.Generic;

namespace DP1_Sudoku.BusinessLogic.Builders
{
    public class FourByFourBoardBuilder : NormalBoardBuilder
    {
        public FourByFourBoardBuilder()
        {
            RowLength = 4;
            ColumnLength = 4;
            SubgroupHeight = 2;
            SubgroupWidth = 2;
        }
    }
}
