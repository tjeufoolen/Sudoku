using DP1_Sudoku.BusinessLogic.Interfaces;
using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic.Strategies.SolveStrategies
{
    public class BackTrackSolveStrategy : ISolveStrategy
    {
        //private static int tryCounter = 0;
        //private static int depthCounter = 0;
        public async Task<bool> SolveBoard(IBoard board, Task? viewUpdate)
        {
            if (board.Cells != null)
            {
                Cell? firstAvailableCell = GetAvailableCell(board.Cells);

                if (firstAvailableCell != null)
                {
                    for (int number = 1; number <= board.MaxValidCellValue; number++)
                    {
                        if (board.IsBoardCorrect())
                        {
                            //Console.WriteLine($"Attempting setting value '{number} (#{tryCounter++} times) (callDepth: {depthCounter})");
                            firstAvailableCell.SetValue(number);

                            if (viewUpdate != null)
                                await viewUpdate;

                            if (await SolveBoard(board, viewUpdate)) return true;
                            else firstAvailableCell.SetValue(0);
                        }
                    }
                    return false;
                }

                return board.IsBoardCorrect();
            }
            return true;
        }

        private static Cell? GetAvailableCell(Cell[,] cells)
        {
            for (int row = 0; row < cells.GetLength(0); row++)
            {
                for (int column = 0; column < cells.GetLength(1); column++)
                {
                    Cell cell = cells[row, column];

                    if (cell.IsSelectable && cell.CurrentValue == null)
                    {
                        return cell;
                    }
                }
            }
            return null;
        }
    }
}