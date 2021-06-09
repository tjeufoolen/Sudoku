using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic.Interfaces
{
    public interface ISolveStrategy
    {
        public Task<bool> SolveBoard(IBoard board, Task? viewUpdate = null);
    }
}