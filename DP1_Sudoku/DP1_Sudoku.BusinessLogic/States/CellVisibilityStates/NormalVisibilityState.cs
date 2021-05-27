using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic.States.CellVisibilityStates
{
    public class NormalVisibilityState : CellVisibilityState
    {
        public NormalVisibilityState(Cell cell) : base(cell)
        {
        }
    }
}
