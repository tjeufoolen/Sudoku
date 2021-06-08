using DP1_Sudoku.BusinessLogic.Builders;

namespace DP1_Sudoku.Tests.Builders
{
    public class SamuraiBoardBuilderTests : BoardBuilderTests
    {
        public SamuraiBoardBuilderTests() : base(
            rows: 9 * 2 + 3, // 9 rows per subgrid, 2 per side, 3 cells whitespace between
            cols: 9 * 2 + 3, // 9 cols per subgrid, 2 per side, 3 cells whitespace between
            subgroups: 9 * 5, //9 subgroups times all subgrids
            verticalGroups: 9 * 5, //9 subgroups times all subgrids
            horizontalGroups: 9 * 5, //9 subgroups times all subgrids
            extension: "samurai"
        )
        { }

        protected override void Init()
        {
            base.Init();

            _builder = new SamuraiBoardBuilder();
        }
    }
}
