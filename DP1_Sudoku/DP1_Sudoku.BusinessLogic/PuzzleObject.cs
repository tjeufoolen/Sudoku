using System;
using System.Threading.Tasks;
namespace DP1_Sudoku.BusinessLogic
{
    public abstract class PuzzleObject
    {
        public string Name { get; set; }
        public string FileExtension { get; set; }
        protected string FilePath { get; set; }

        public PuzzleObject(string fileLocation)
        {
            if (string.IsNullOrWhiteSpace(fileLocation)) throw new ArgumentNullException($"{GetType().Name} requires a file location, but none was provided");

            SetIdentifiers(fileLocation);
            if (string.IsNullOrEmpty(Name)) throw new ArgumentNullException($"{typeof(PuzzleObject)} requires a {nameof(Name)}");
            if (string.IsNullOrEmpty(FileExtension)) throw new ArgumentNullException($"{typeof(PuzzleObject)} requires a {nameof(FileExtension)}");
            if (string.IsNullOrEmpty(FilePath)) throw new ArgumentNullException($"{typeof(PuzzleObject)} requires a {nameof(FilePath)}");
        }

        public abstract Task<string[]> GetPuzzleString();

        protected abstract void SetIdentifiers(string fileLocation);
    }
}
