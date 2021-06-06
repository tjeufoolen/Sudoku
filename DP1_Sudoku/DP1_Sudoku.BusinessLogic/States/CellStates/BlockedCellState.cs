using System;

namespace DP1_Sudoku.BusinessLogic.States.CellStates
{
    public class BlockedCellState : CellState
    {
        public override bool IsSelectable { get; protected set; } = false;

        public BlockedCellState(Cell cell) : base(cell)
        {
        }

        public override bool SetValue(int value)
        {
            throw new NotImplementedException();
        }

        public override bool ToggleHelpNumber(int value)
        {
            throw new NotImplementedException();
        }
    }
}
