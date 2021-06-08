using DP1_Sudoku.BusinessLogic.Interfaces;
using DP1_Sudoku.BusinessLogic.States.CellStates;
using System;
using System.Collections.Generic;

namespace DP1_Sudoku.BusinessLogic
{
    public class Cell : IGridComponent
    {
        private CellState _state;
        //TODO: uncomment if still needed. if not, remove at the end.
        //public CellVisibilityState CellVisibilityState { private get; set; }

        public Cell? Left { get; set; }
        public Cell? Right { get; set; }
        public Cell? Top { get; set; }
        public Cell? Bottom { get; set; }

        private int? _currentValue;
        public int? CurrentValue
        {
            get => _currentValue;
            set
            {
                if (value == 0) _currentValue = null;
                else _currentValue = value;
            }
        }

        public List<int> HelpNumbers { get; private set; } = new();

        public bool IsSelectable { get => _state.IsSelectable; }

        public bool IsDrawable { get => _state.IsDrawable; }

        public Cell(int value)
        {
            CurrentValue = value;

            _state = GetStateByValue(value);
        }

        private CellState GetStateByValue(int? value)
        {
            if (value == null || value == 0)
                return new EmptyCellState(this);

            return new DefinitiveCellState(this);
        }

        public void SetState(CellState state) => this._state = state;

        public bool SetValue(int value) => _state.SetValue(value);

        public void ToggleHelpNumber(int value) => _state.ToggleHelpNumber(value);

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
            if (component == null || component is not Cell otherAsCell) return false;
            return otherAsCell.CurrentValue == this.CurrentValue;
        }
    }
}
