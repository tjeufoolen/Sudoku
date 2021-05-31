using DP1_Sudoku.BusinessLogic.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic.Strategies.PuzzleLoadingStrategies
{
    public class LocalPuzzleStrategy : IPuzzleLoadingStrategy
    {
        public Task<List<PuzzleObject>> GetPuzzles()
        {
            List<string> fileOptions = LoadAvailableFiles();
            List<PuzzleObject> puzzles = ConvertToPuzzleObject(fileOptions);
            return Task.FromResult(puzzles);
        }

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
            return fileOptions
                .Select(puzzle => new PuzzleObject("", ""))
                .ToList();
        }
    }
}
