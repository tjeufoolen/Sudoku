using DP1_Sudoku.BusinessLogic.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic.Strategies.PuzzleLoadingStrategies
{
    public class LocalPuzzleStrategy : IPuzzleLoadingStrategy
    {
        public Task<PuzzleObject?> GetPuzzle(string name, string extension)
        {
            var puzzles = LoadAvailableFiles();
            var targetPuzzle = puzzles.FirstOrDefault(puzzle => puzzle.EndsWith($"{name}.{extension}"));

            if (targetPuzzle == null)
                return Task.FromResult<PuzzleObject?>(null);

            return Task.FromResult<PuzzleObject?>(new EmbeddedPuzzleObject(targetPuzzle));
        }

        public Task<List<PuzzleObject>> GetPuzzles()
        {
            List<string> fileOptions = LoadAvailableFiles();
            List<PuzzleObject> puzzles = ConvertToPuzzleObject(fileOptions);
            return Task.FromResult(puzzles);
        }

        #region Helpers
        private static List<string> LoadAvailableFiles()
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceNames().Where(name =>
            {
                return name.StartsWith("DP1_Sudoku.BusinessLogic.Resources.Puzzles.");
            }).ToList();
        }

        private static List<PuzzleObject> ConvertToPuzzleObject(List<string> fileOptions)
        {
            List<PuzzleObject> puzzles = new();
            puzzles.AddRange(fileOptions.Select(puzzle => new EmbeddedPuzzleObject(puzzle)));
            return puzzles;
        }
        #endregion Helpers
    }
}
