using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic
{
    public class Main
    {
        //public Game Game { get; private set; }
        public async Task LoadGame(string[] args)
        {
            Game game = new();
            await game.LoadPuzzleOptions();
        }
    }
}