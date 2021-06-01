namespace DP1_Sudoku.Shared
{
    public partial class Puzzle
    {
        private PuzzleCell _selectedCell;

        public PuzzleCell SelectedCell
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
