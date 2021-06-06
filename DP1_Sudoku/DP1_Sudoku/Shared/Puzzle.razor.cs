using DP1_Sudoku.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Components;

namespace DP1_Sudoku.Shared
{
    public partial class Puzzle
    {
        [Parameter] public IBoard? Board { get; set; }

        private PuzzleCell? _selectedCell = null;

        public PuzzleCell? SelectedCell
        {
            get { return _selectedCell; }
            set
            {
                if (value != _selectedCell)
                {
                    _selectedCell = value;
                    InvokeAsync(StateHasChanged);
                }

            }
        }
    }
}
