namespace DP1_Sudoku.BusinessLogic.States.CellStates
{
    public class FilledCellState : CellState
    {
        public override bool IsSelectable { get; protected set; } = true;

        public FilledCellState(Cell cell) : base(cell)
        {
        }

        public override bool SetValue(int value)
        {
            if (IsValidValue(value))
            {
                if (Cell.CurrentValue == null || Cell.CurrentValue == value || value == 0)
                {
                    Cell.CurrentValue = null;
                    Cell.SetState(new EmptyCellState(Cell));
                    return true;
                }

                Cell.CurrentValue = value;
                return true;
            }
            return false;
        }
    }
}
