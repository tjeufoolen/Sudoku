using DP1_Sudoku.BusinessLogic;
using DP1_Sudoku.Pages.Game;
using Microsoft.AspNetCore.Components;

namespace DP1_Sudoku.Shared
{
    public partial class PuzzleCellComponent
    {
        [Parameter] public Cell? Cell { get; set; }
        [Parameter] public EventCallback<Cell?> CellChanged { get; set; }
        [CascadingParameter] public PuzzleComponent? Parent { get; set; }
        [CascadingParameter] public PuzzleDisplaySettings? DisplaySettings { get; set; }

        public bool IsSelected => Parent?.SelectedCellComponent == this;

        public void Select()
        {
            if (Parent != null && Cell != null && Cell.IsSelectable)
                Parent.SelectedCellComponent = this;
        }

        private bool ShowAuxiliaryNumbers()
        {
            if (Cell?.CurrentValue != null) return false;
            return DisplaySettings != null ? DisplaySettings.ShowAuxiliaryNumbers : true;
        }

        private bool ColorInvalidNumbers()
        {
            return DisplaySettings != null ? DisplaySettings.ColorInvalidNumbers : true;
        }
    }
}
