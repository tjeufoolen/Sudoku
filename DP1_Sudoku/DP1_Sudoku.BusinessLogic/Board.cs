using DP1_Sudoku.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP1_Sudoku.BusinessLogic
{
    public class Board : IBoard
    {
        public ISolveStrategy SolveStrategy { private get; set; }

        public IList<IList<Cell>> Cells { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IList<Group> Groups { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Solve()
        {
            SolveStrategy.SolveBoard(this);
        }

        public void Accept(IVisitor visitor)
        {
            throw new NotImplementedException();
        }

        public bool Validate()
        {
            throw new NotImplementedException();
        }

        public virtual bool ValidateGroups()
        {
            throw new NotImplementedException();
        }

        public virtual bool ValidateHorizontal()
        {
            throw new NotImplementedException();
        }

        public virtual bool ValidateVertical()
        {
            throw new NotImplementedException();
        }
    }
}