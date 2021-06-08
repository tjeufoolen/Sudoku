using System.Collections.Generic;
using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic.Interfaces
{
    public interface IPuzzleObjectFactory
    {
        bool AddLoadingStrategy(IPuzzleLoadingStrategy loadingStrategy);
        bool RemoveLoadingStrategy(IPuzzleLoadingStrategy loadingStrategy);
        Task<PuzzleObject?> LoadPuzzle(string name, string extension);
        Task<List<PuzzleObject>> LoadAll();
    }
}