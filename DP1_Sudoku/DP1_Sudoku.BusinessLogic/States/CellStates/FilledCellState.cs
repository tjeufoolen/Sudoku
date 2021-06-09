using System.Linq;

namespace DP1_Sudoku.BusinessLogic.States.CellStates
{
    public class FilledCellState : CellState
    {
        public override bool IsSelectable { get; protected set; } = true;
        public override bool IsDrawable { get; protected set; } = true;
        public override bool IsValid { get; protected set; } = true;

        public FilledCellState(Cell cell) : base(cell)
        {
        }

        public override bool SetValue(int value)
        {
            if (IsValidValue(value))
            {
                if (Cell.CurrentValue == null || Cell.CurrentValue == value || value == 0)
                {
                    Cell.CurrentValue = null;
                    Cell.SetState(new EmptyCellState(Cell));
                    return true;
                }

                Cell.CurrentValue = value;
                return true;
            }
            return false;
        }

        public override bool Validate()
        {
            bool cellValueExistsInGroup = Cell.ValidationGroups.Any(group => group.Children.Any(otherCell => otherCell != Cell && otherCell.IsEqualTo(Cell)));

            if (cellValueExistsInGroup)
            {
                Cell.SetState(new InvalidCellState(Cell));
                return false;
            }

            return true;
        }
    }
}
