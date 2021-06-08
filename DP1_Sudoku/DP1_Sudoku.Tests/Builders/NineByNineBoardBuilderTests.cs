using DP1_Sudoku.BusinessLogic.Builders;

namespace DP1_Sudoku.Tests.Builders
{
    public class NineByNineBoardBuilderTests : NormalBoardBuilderTests
    {
        public NineByNineBoardBuilderTests() : base(
            rows: 9,
            cols: 9,
            subgroups: 9,
            verticalGroups: 9,
            horizontalGroups: 9,
            extension: "9x9"
        )
        { }

        protected override void Init()
        {
            base.Init();

            _builder = new NineByNineBoardBuilder();
        }
    }
}
