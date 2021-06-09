using System.Collections.Generic;
using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic.Interfaces
{
    public interface IBoard : IGridComponent
    {
        Cell[,]? Cells { get; set; }
        int MaxValidCellValue { get; }

        IList<IGridComponent> SubGroups { get; set; }
        IList<IGridComponent> HorizontalGroups { get; set; }
        IList<IGridComponent> VerticalGroups { get; set; }

        ISolveStrategy? SolveStrategy { get; set; }

        bool IsBoardCorrect();
        void VerifyBoard();
        bool ValidateGroups();

        Task Solve(Task onCellValueUpdate);
    }
}
