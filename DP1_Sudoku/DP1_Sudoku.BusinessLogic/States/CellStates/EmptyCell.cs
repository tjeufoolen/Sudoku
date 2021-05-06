using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP1_Sudoku.BusinessLogic.States.CellStates
{
    public class EmptyCell : CellState
    {
        public EmptyCell(Cell cell) : base(cell)
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