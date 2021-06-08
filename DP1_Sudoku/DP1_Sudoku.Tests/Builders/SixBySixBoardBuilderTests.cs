using DP1_Sudoku.BusinessLogic.Builders;

namespace DP1_Sudoku.Tests.Builders
{
    public class SixBySixBoardBuilderTests : BoardBuilderTests
    {
        public SixBySixBoardBuilderTests() : base(
            rows: 6,
            cols: 6,
            subgroups: 6,
            verticalGroups: 6,
            horizontalGroups: 6,
            extension: "6x6"
        )
        { }

        protected override void Init()
        {
            base.Init();

            _builder = new SixBySixBoardBuilder();
        }
    }
}
