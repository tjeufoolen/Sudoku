﻿namespace DP1_Sudoku.BusinessLogic.States.CellStates
{
    public class EmptyCellState : CellState
    {
        public override bool IsSelectable { get; protected set; } = true;
        public override bool IsDrawable { get; protected set; } = true;
        public override bool IsValid { get; protected set; } = true;

        public EmptyCellState(Cell cell) : base(cell)
        {
        }

        public override bool SetValue(int value)
        {
            if (IsValidValue(value))
            {
                if (value == 0) return false;
                Cell.CurrentValue = value;
                Cell.SetState(new FilledCellState(Cell));
                return true;
            }
            return false;
        }

        public override bool Validate() => false;
    }
}