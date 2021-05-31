using DP1_Sudoku.BusinessLogic.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic.Interfaces
{
    public interface IPuzzleFactory
    {
        void AddLoadingStrategy(IPuzzleLoadingStrategy loadingStrategy);
        Task<List<PuzzleObject>> Load(IPuzzleLoadingStrategy loadingStrategy);
        Task<List<PuzzleObject>> LoadAll();
        void RemoveLoadingStrategy(IPuzzleLoadingStrategy loadingStrategy);
    }
}