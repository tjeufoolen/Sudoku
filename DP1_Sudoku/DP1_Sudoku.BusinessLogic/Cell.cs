using DP1_Sudoku.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DP1_Sudoku.BusinessLogic.States.CellStates;
using DP1_Sudoku.BusinessLogic.States.CellVisibilityStates;

namespace DP1_Sudoku.BusinessLogic
{
    public class Cell : IGridComponent
    {
        public CellState CellState { private get; set; }
        public CellVisibilityState CellVisibilityState { private get; set; }
        
        public Cell Left { get; set; }
        public Cell Right { get; set; }
        public Cell Top { get; set; }
        public Cell Bottom { get; set; }
        
        public int CurrentValue { get; set; }

        public List<int> HelpNumbers { get; private set; } = new();

        public bool SetValue(int newValue)
        {
            throw new NotImplementedException();
        }

        public void ToggleHelpNumber(int value)
        {
            throw new NotImplementedException();
        }

        public void Accept(IVisitor visitor)
        {
            throw new NotImplementedException();
        }

        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
