using DP1_Sudoku.BusinessLogic.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic
{
    public class PuzzleObjectFactory : IPuzzleObjectFactory
    {
        private readonly List<IPuzzleLoadingStrategy> _loadingStrategies;
        public PuzzleObjectFactory(IEnumerable<IPuzzleLoadingStrategy>? loadingStrategies = null)
        {
            _loadingStrategies = new List<IPuzzleLoadingStrategy>();
            if (loadingStrategies != null)
                _loadingStrategies.AddRange(loadingStrategies);
        }

        public async Task<List<PuzzleObject>> LoadAll()
        {
            List<PuzzleObject> puzzles = new();

            foreach (var strategy in _loadingStrategies)
            {
                puzzles.AddRange(await strategy.GetPuzzles());
            }

            return puzzles;
        }

        public async Task<List<PuzzleObject>> Load(IPuzzleLoadingStrategy loadingStrategy)
        {
            return await loadingStrategy.GetPuzzles();
        }

        public void AddLoadingStrategy(IPuzzleLoadingStrategy loadingStrategy)
        {
            if (!_loadingStrategies.Contains(loadingStrategy))
            {
                _loadingStrategies.Add(loadingStrategy);
            }
        }

        public void RemoveLoadingStrategy(IPuzzleLoadingStrategy loadingStrategy)
        {
            _loadingStrategies.Remove(loadingStrategy);
        }

        public async Task<PuzzleObject?> LoadPuzzle(string name, string extension)
        {
            PuzzleObject? puzzle = null;

            foreach (var strategy in _loadingStrategies)
            {
                puzzle = await strategy.GetPuzzle(name, extension);
                if (puzzle != null) break;
            }

            return puzzle;
        }
    }
}
