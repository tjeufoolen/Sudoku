namespace DP1_Sudoku.BusinessLogic.States.CellStates
{
    public class BlockedCellState : CellState
    {
        public override bool IsSelectable { get; protected set; } = false;
        public override bool IsDrawable { get; protected set; } = false;
        public override bool IsValid { get; protected set; } = true;

        public BlockedCellState(Cell cell) : base(cell)
        {
        }

        public override bool SetValue(int _) => false;

        public override bool ToggleHelpNumber(int _) => false;

        public override bool Validate()
        {
            return true;
        }
    }
}
