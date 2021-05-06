using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic.States.CellStates
{
    public class DefinitiveCell : CellState
    {
        public DefinitiveCell(Cell cell) : base(cell)
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
