using DP1_Sudoku.BusinessLogic;
using Microsoft.AspNetCore.Components;

namespace DP1_Sudoku.Shared
{
    public partial class PuzzleCellComponent
    {
        [Parameter] public Cell? Cell { get; set; }
        [Parameter] public EventCallback<Cell?> CellChanged { get; set; }
        [CascadingParameter] public PuzzleComponent? Parent { get; set; }

        public bool IsSelected => Parent?.SelectedCellComponent == this;

        public void Select()
        {
            if (Parent != null && Cell != null && Cell.IsSelectable)
                Parent.SelectedCellComponent = this;
        }
    }
}
