using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic.Interfaces
{
    interface IBoardBuilder
    {
        public abstract IBoard Board { get; protected set; }

        public abstract void Reset();
        public abstract void BuildCells(IList<string> lines);
        public abstract void BuildGroups(IList<string> lines);
    }
}
