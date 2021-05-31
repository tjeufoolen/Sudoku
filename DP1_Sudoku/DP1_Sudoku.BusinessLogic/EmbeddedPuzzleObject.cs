using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic
{
    public class EmbeddedPuzzleObject : PuzzleObject
    {
        public EmbeddedPuzzleObject(string embeddedLocation) : base(embeddedLocation)
        {
        }

        public override async Task<string[]> GetPuzzleString()
        {
            Assembly assembly = GetType().Assembly;
            Stream? fileStream = assembly.GetManifestResourceStream(FilePath);

            if (fileStream == null) throw new InvalidOperationException($"{GetType()} cannot load it's puzzleString. No file found to read from. Tried to read from: {FilePath}. ");

            StreamReader reader = new(fileStream);
            string fileContent = await reader.ReadToEndAsync();
            string[] lines = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            return lines;
        }

        protected override void SetIdentifiers(string fileLocation)
        {
            string[] locationNameSpaces = fileLocation.Split('.');
            FilePath = fileLocation;
            FileExtension = locationNameSpaces[^1];
            Name = locationNameSpaces[^2];
        }
    }
}