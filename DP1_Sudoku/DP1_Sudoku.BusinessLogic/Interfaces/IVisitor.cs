using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic.Interfaces
{
    public interface IVisitor
    {
        public abstract void Visit(Board board);
        public abstract void Visit(Group group);
        public abstract void Visit(Cell cell);
    }
}
