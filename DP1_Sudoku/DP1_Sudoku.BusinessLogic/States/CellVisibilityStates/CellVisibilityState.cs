using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic.States.CellVisibilityStates
{
    public abstract class CellVisibilityState
    {
        protected Cell Cell { get; set; }
        public CellVisibilityState(Cell cell)
        {
            Cell = cell;
        }
    }
}
