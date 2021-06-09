using System.Collections.Generic;

namespace DP1_Sudoku.BusinessLogic.Interfaces
{
    public interface IBoardBuilder
    {
        IBoard Board { get; }

        abstract void Reset();
        abstract void BuildCells(IList<string> lines);
        abstract void BuildGroups(IList<string> lines);
    }
}
