using System;

namespace DP1_Sudoku.BusinessLogic.States.CellStates
{
    public abstract class CellState
    {
        protected Cell Cell { get; set; }
        public virtual bool IsSelectable { get; protected set; }
        public virtual bool IsDrawable { get; protected set; }

        public CellState(Cell cell)
        {
            Cell = cell;
        }

        public virtual bool SetValue(int value)
        {
            throw new NotImplementedException();
        }

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

        protected bool IsValidValue(int value) => value >= 0 && value <= 9;
    }
}