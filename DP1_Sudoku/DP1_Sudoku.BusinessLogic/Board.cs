using DP1_Sudoku.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;

namespace DP1_Sudoku.BusinessLogic
{
    public class Board : IBoard
    {
        public ISolveStrategy? SolveStrategy { private get; set; }

        public Cell[,]? Cells { get; set; }
        public IList<GroupComposite> SubGroups { get; set; } = new List<GroupComposite>();
        public IList<GroupComposite> HorizontalGroups { get; set; } = new List<GroupComposite>();
        public IList<GroupComposite> VerticalGroups { get; set; } = new List<GroupComposite>();

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

        public bool IsEqualTo(IGridComponent component)
        {
            if (component == null || component is not Board otherAsBoard) return false;
            return otherAsBoard == this;
        }
    }
}
