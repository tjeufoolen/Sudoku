using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic
{
    public class Main
    {
        public static async Task LoadGame()
        {
            await new Game().LoadPuzzleOptions();
        }
    }
}