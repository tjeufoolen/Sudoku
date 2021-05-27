using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP1_Sudoku.BusinessLogic.Interfaces
{
    public interface IBoard : IGridComponent
    {
        IList<IList<Cell>> Cells { get; set; }
        IList<GroupComposite> Groups { get; set; }
        public bool ValidateGroups();
    }
}
