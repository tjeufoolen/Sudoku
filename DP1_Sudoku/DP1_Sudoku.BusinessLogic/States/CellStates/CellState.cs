namespace DP1_Sudoku.BusinessLogic.States.CellStates
{
    public abstract class CellState
    {
        protected Cell Cell { get; set; }
        public virtual bool IsSelectable { get; protected set; }
        public virtual bool IsDrawable { get; protected set; }
        public virtual bool IsValid { get; protected set; }

        public CellState(Cell cell)
        {
            Cell = cell;
        }

        public abstract bool SetValue(int value);

        public abstract bool Validate();


        public virtual bool ToggleHelpNumber(int value)
        {
            if (IsValidValue(value))
            {
                if (Cell.HelpNumbers.Contains(value))
                    Cell.HelpNumbers.Remove(value);
                else
                    Cell.HelpNumbers.Add(value);

                return true;
            }
            return false;
        }

        protected static bool IsValidValue(int value) => value >= 0 && value <= 9;
    }
}