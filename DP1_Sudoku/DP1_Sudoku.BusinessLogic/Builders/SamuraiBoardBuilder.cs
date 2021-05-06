using DP1_Sudoku.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic.Builders
{
    class SamuraiBoardBuilder : IBoardBuilder
    {
        IBoard IBoardBuilder.Board { get; set; }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void BuildCells(IList<string> lines)
        {
            throw new NotImplementedException();
        }

        public void BuildGroups(IList<string> lines)
        {
            throw new NotImplementedException();
        }
    }
}
