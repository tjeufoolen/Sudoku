using System.Collections.Generic;

namespace DP1_Sudoku.BusinessLogic.Interfaces
{
    public interface IBoard : IGridComponent
    {
        Cell[,]? Cells { get; set; }
        IList<GroupComposite> SubGroups { get; set; }
        IList<GroupComposite> HorizontalGroups { get; set; }
        IList<GroupComposite> VerticalGroups { get; set; }
        public int MaxValidCellValue { get; }
        public bool ValidateGroups();
        void VerifyBoard();
    }
}
