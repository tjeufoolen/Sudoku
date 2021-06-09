using DP1_Sudoku.BusinessLogic.Interfaces;
using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic.Strategies.SolveStrategies
{
    public class BackTrackSolveStrategy : ISolveStrategy
    {
        public async Task<bool> SolveBoard(IBoard board, Task? onCellValueUpdate)
        {
            if (board.Cells == null) return false;

            Cell? firstAvailableCell = GetAvailableCell(board.Cells);
            if (firstAvailableCell != null)
            {
                for (int number = 1; number <= board.MaxValidCellValue; number++)
                {
                    if (board.IsBoardCorrect())
                    {
                        firstAvailableCell.SetValue(number);
                        if (onCellValueUpdate != null) await onCellValueUpdate;

                        if (await SolveBoard(board, onCellValueUpdate)) return true;
                        else firstAvailableCell.SetValue(0);
                    }
                }
                return false;
            }
            return board.IsBoardCorrect();
        }

        #region Helpers
        private static Cell? GetAvailableCell(Cell[,] cells)
        {
            for (int row = 0; row < cells.GetLength(0); row++)
            {
                for (int column = 0; column < cells.GetLength(1); column++)
                {
                    Cell cell = cells[row, column];

                    if (cell.IsSelectable && cell.CurrentValue == null) return cell;
                }
            }
            return null;
        }
        # endregion Helpers
    }
}