using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP1_Sudoku.BusinessLogic.Interfaces
{
    public interface ISolveStrategy
    {
        public void SolveBoard(IBoard board);
    }
}