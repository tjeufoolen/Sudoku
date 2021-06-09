using System.Linq;

namespace DP1_Sudoku.BusinessLogic.States.CellStates
{
    public class InvalidCellState : FilledCellState
    {
        public override bool IsValid { get; protected set; } = false;

        public InvalidCellState(Cell cell) : base(cell)
        {
        }

        public override bool Validate()
        {
            bool cellValueExistsInGroup = Cell.ValidationGroups.Any(group => group.Children.Any(otherCell => otherCell != Cell && otherCell.IsEqualTo(Cell)));

            if (!cellValueExistsInGroup)
            {
                Cell.SetState(new FilledCellState(Cell));
                return true;
            }
            return false;
        }
    }
}
