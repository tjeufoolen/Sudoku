using System.Collections.Generic;

namespace DP1_Sudoku.BusinessLogic.Interfaces
{
    public interface IBoard : IGridComponent
    {
        Cell[,]? Cells { get; set; }
        IList<GroupComposite> Groups { get; set; }
        public bool ValidateGroups();
    }
}
