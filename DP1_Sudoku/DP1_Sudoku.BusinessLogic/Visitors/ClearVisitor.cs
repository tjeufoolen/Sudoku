using DP1_Sudoku.BusinessLogic.Extensions;
using DP1_Sudoku.BusinessLogic.Interfaces;

namespace DP1_Sudoku.BusinessLogic.Visitors
{
    public class ClearVisitor : IVisitor
    {
        public void Visit(Board board)
        {
            if (board.Cells != null)
            {
                for (int rowIdx = 0; rowIdx < board.Cells.GetLength(0); rowIdx++)
                {
                    for (int colIdx = 0; colIdx < board.Cells.GetLength(1); colIdx++)
                    {
                        board.Cells[rowIdx, colIdx].Accept(this);
                    }
                }
            }
        }

        public void Visit(GroupComposite group)
        {
            group.Children.ForEach(c => c.Accept(this));
        }

        public void Visit(Cell cell)
        {
            cell.SetValue(0);
        }
    }
}
