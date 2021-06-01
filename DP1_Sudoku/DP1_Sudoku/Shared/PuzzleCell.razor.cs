using Microsoft.AspNetCore.Components;

namespace DP1_Sudoku.Shared
{
    public partial class PuzzleCell
    {
        [CascadingParameter] public Puzzle Parent { get; set; }

        public bool IsSelected => Parent.SelectedCell == this;

        public void Select()
        {
            Parent.SelectedCell = this;
        }
    }
}
