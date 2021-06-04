using System.Collections.Generic;

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
