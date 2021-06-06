using DP1_Sudoku.BusinessLogic;
using DP1_Sudoku.BusinessLogic.Factories;
using DP1_Sudoku.BusinessLogic.Interfaces;
using DP1_Sudoku.BusinessLogic.Strategies.CellValueStrategies;
using DP1_Sudoku.Shared;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace DP1_Sudoku.Pages.Game
{
    public partial class GamePage
    {
        [Parameter] public string? Name { get; set; }
        [Parameter] public string? Extension { get; set; }
        [Inject] public NavigationManager? NavManager { get; set; }
        [Inject] public IPuzzleObjectFactory? PuzzleObjectFactory { get; set; }

        private IBoard? _board;
        private PuzzleComponent? _puzzle;
        private bool _showAuxiliaryNumbers = false;
        private bool _colorInvalidNumbers = false;

        protected override async Task OnParametersSetAsync()
        {
            // Check if parameters have been set
            if (Name == null || Extension == null)
            {
                NavManager?.NavigateTo("/gameNotFound");
                await base.OnParametersSetAsync();
                return;
            }

            // Check if dependency injection found all needed objects
            if (PuzzleObjectFactory == null)
            {
                await base.OnParametersSetAsync();
                return;
            }

            // Fetch puzzle from parameters
            PuzzleObject? _puzzle = await PuzzleObjectFactory.LoadPuzzle(Name, Extension);

            // Check if puzzle exists
            if (_puzzle == null)
            {
                NavManager?.NavigateTo("/gameNotFound");
                await base.OnParametersSetAsync();
                return;
            }

            // Init puzzle
            await InitPuzzle(_puzzle);

            // Call base
            await base.OnParametersSetAsync();
        }

        private async Task InitPuzzle(PuzzleObject puzzleObject)
        {
            string extension = puzzleObject.FileExtension;
            string[] lines = await puzzleObject.GetPuzzleString();

            _board = BoardFactory.GetInstance().CreateBoard(extension, lines);
        }

        private void ToggleShowAuxiliaryNumbers() => _showAuxiliaryNumbers = !_showAuxiliaryNumbers;

        private void ToggleColorInvalidNumbers() => _colorInvalidNumbers = !_colorInvalidNumbers;

        #region Set Selected Cell Value
        public enum EditMode { Auxiliary, Final }
        private ICellValueStrategy _setCellValueStrategy = new CellValueStrategy();
        private EditMode _currentEditMode = EditMode.Final;
        private int _numberInput;

        private void SetCellValue(int value)
        {
            Cell? selectedCell = _puzzle?.SelectedCellComponent?.Cell;
            if (selectedCell != null) _setCellValueStrategy.SetValue(selectedCell, value);
        }

        private void SwitchEditMode()
        {
            if (_currentEditMode == EditMode.Final)
            {
                _currentEditMode = EditMode.Auxiliary;
                _setCellValueStrategy = new AuxiliaryCellValueStrategy();
            }
            else
            {
                _currentEditMode = EditMode.Final;
                _setCellValueStrategy = new CellValueStrategy();
            }
        }
        #endregion Set Selected Cell Value
    }
}