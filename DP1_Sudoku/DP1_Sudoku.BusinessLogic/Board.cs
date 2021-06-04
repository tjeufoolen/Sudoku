using DP1_Sudoku.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;

namespace DP1_Sudoku.BusinessLogic
{
    public class Board : IBoard
    {
        public ISolveStrategy? SolveStrategy { private get; set; }

        public Cell[,]? Cells { get; set; }
        public IList<GroupComposite> Groups { get; set; } = new List<GroupComposite>();

        public void Solve()
        {
            SolveStrategy?.SolveBoard(this);
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
    }
}
