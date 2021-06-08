using DP1_Sudoku.BusinessLogic.Builders;

namespace DP1_Sudoku.Tests.Builders
{
    public class JigsawBoardBuilderTests : BoardBuilderTests
    {
        public JigsawBoardBuilderTests() : base(
            rows: 9,
            cols: 9,
            subgroups: 9,
            verticalGroups: 9,
            horizontalGroups: 9,
            extension: "jigsaw"
        )
        { }

        protected override void Init()
        {
            base.Init();

            _builder = new JigsawBoardBuilder();
        }
    }
}
