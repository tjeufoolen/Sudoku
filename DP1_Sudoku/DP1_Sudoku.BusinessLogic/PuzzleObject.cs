using DP1_Sudoku.BusinessLogic.Enumerators;
using DP1_Sudoku.BusinessLogic.Factories;
using DP1_Sudoku.BusinessLogic.Interfaces;
using DP1_Sudoku.BusinessLogic.Utils;

namespace DP1_Sudoku.BusinessLogic
{
    public class PuzzleObject
    {
        public string Name { get; private set; }
        public string FilePath { get; private set; }
        public BoardTypes Type { get; private set; }
        public IFileReaderStrategy FileReader { get; private set; }

        public PuzzleObject(string name, string filePath)
        {
            this.Name = name;
            this.FilePath = filePath;
            this.Type = GetType(this.FilePath);
            this.FileReader = GetFileReader(this.FilePath);
        }

        private BoardTypes GetType(string filePath)
        {
            string fileName = FilePathUtil.GetFileName(filePath).ToLower();

            if (fileName.Contains("samurai"))
                return BoardTypes.SAMURAI;
            if (fileName.Contains("jigsaw"))
                return BoardTypes.JIGSAW;

            return BoardTypes.NORMAL;
        }

        private IFileReaderStrategy GetFileReader(string filePath)
        {
            FileReaderFactory factory = FileReaderFactory.GetInstance();

            if (filePath.Contains("http://") || filePath.Contains("https://"))
                return factory.GetFileReader(FileReaderTypes.ONLINE);

            return factory.GetFileReader(FileReaderTypes.OFFLINE);
        }
    }
}
