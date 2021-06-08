using DP1_Sudoku.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;

namespace DP1_Sudoku.BusinessLogic
{
    public class GroupComposite : IGridComponent
    {

        public IList<IGridComponent> Children { get; set; } = new List<IGridComponent>();

        public void Accept(IVisitor visitor)
        {
            throw new NotImplementedException();
        }

        public bool Validate()
        {
            throw new NotImplementedException();
        }

        public bool IsEqualTo(IGridComponent component)
        {
            if (component == null || component is not GroupComposite otherAsGroup) return false;
            return otherAsGroup == this;
        }

    }
}
