using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP1_Sudoku.BusinessLogic.Interfaces
{
    public interface IGridComponent
    {
        public void Accept(IVisitor visitor);
        public bool Validate();
    }
}