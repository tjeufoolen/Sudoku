using System.Collections.Generic;
using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic.Interfaces
{
    public interface IPuzzleLoadingStrategy
    {
        Task<PuzzleObject?> GetPuzzle(string extension, string name);
        Task<List<PuzzleObject>> GetPuzzles();
    }
}