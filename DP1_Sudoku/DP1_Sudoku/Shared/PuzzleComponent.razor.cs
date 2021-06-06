using DP1_Sudoku.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Components;

namespace DP1_Sudoku.Shared
{
    public partial class PuzzleComponent
    {
        [Parameter] public IBoard? Board { get; set; }

        private PuzzleCellComponent? _selectedCellComponent = null;

        public PuzzleCellComponent? SelectedCellComponent
        {
            get { return _selectedCellComponent; }
            set
            {
                if (value != _selectedCellComponent)
                {
                    _selectedCellComponent = value;
                    InvokeAsync(StateHasChanged);
                }

            }
        }
    }
}
