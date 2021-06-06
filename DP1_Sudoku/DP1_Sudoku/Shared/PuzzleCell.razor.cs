using DP1_Sudoku.BusinessLogic;
using DP1_Sudoku.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Components;

namespace DP1_Sudoku.Shared
{
    public partial class PuzzleCell
    {
        [Parameter] public Cell? Cell { get; set; }
        [Parameter] public EventCallback<Cell?> CellChanged { get; set; }
        [CascadingParameter] public Puzzle? Parent { get; set; }

        public bool IsSelected => Parent?.SelectedCell == this;

        public void Select()
        {
            if (Parent != null && Cell != null && Cell.IsSelectable)
                Parent.SelectedCell = this;
        }
    }
}
