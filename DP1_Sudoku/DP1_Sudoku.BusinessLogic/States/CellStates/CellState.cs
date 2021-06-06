using System;

namespace DP1_Sudoku.BusinessLogic.States.CellStates
{
    public abstract class CellState
    {
        protected Cell Cell { get; set; }
        public virtual bool IsSelectable { get; protected set; }

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
            throw new NotImplementedException();
        }
    }
}