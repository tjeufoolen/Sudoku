using DP1_Sudoku.BusinessLogic.Builders;

namespace DP1_Sudoku.Tests.Builders
{
    public class FourByFourBoardBuilderTests : BoardBuilderTests
    {
        public FourByFourBoardBuilderTests() : base(
            rows: 4,
            cols: 4,
            subgroups: 4,
            verticalGroups: 4,
            horizontalGroups: 4,
            extension: "4x4"
        )
        { }

        protected override void Init()
        {
            base.Init();

            _builder = new FourByFourBoardBuilder();
        }
    }
}
