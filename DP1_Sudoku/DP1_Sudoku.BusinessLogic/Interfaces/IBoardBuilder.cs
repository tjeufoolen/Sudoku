using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic.Interfaces
{
    public interface IBoardBuilder
    {
        IBoard Board { get; }

        public abstract void Reset();
        public abstract void BuildCells(IList<string> lines);
        public abstract void BuildGroups(IList<string> lines);
    }
}
