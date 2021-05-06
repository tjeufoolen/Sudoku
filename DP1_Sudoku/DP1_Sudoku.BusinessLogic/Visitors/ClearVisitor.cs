using DP1_Sudoku.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic.Visitors
{
    public class ClearVisitor : IVisitor
    {
        public void Visit(Board board)
        {
            throw new NotImplementedException();
        }

        public void Visit(Group group)
        {
            throw new NotImplementedException();
        }

        public void Visit(Cell cell)
        {
            throw new NotImplementedException();
        }
    }
}
