namespace DP1_Sudoku.BusinessLogic.States.CellStates
{
    public class EmptyCellState : CellState
    {
        public override bool IsSelectable { get; protected set; } = true;

        public EmptyCellState(Cell cell) : base(cell)
        {
        }

        public override bool SetValue(int value)
        {
            if (IsValidValue(value))
            {
                Cell.CurrentValue = value;
                Cell.SetState(new FilledCellState(Cell));
                return true;
            }
            return false;
        }
    }
}