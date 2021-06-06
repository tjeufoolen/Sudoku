using DP1_Sudoku.BusinessLogic;
using DP1_Sudoku.BusinessLogic.Factories;
using DP1_Sudoku.BusinessLogic.Interfaces;
using DP1_Sudoku.BusinessLogic.Strategies.CellValueStrategies;
using DP1_Sudoku.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace DP1_Sudoku.Pages.Game
{
    public partial class GamePage
    {
        [Parameter] public string? Name { get; set; }
        [Parameter] public string? Extension { get; set; }
        [Inject] NavigationManager? NavManager { get; set; }
        [Inject] IPuzzleObjectFactory? PuzzleObjectFactory { get; set; }

        private ICellValueStrategy _setCellValueStrategy = new DefinitiveCellValueStrategy();
        private IBoard? _board;
        private Puzzle? _puzzle;

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

        public EditMode CurrentEditMode = EditMode.Final;
        public bool ShowAuxiliaryNumbers { get; private set; } = false;
        public bool ColorInvalidNumbers { get; private set; } = false;
        private int _numberInput;

        public void SetCellValue(int value)
        {
            Cell? selectedCell = _puzzle?.SelectedCell?.Cell;
            if (selectedCell != null) _setCellValueStrategy.SetValue(selectedCell, value);
        }

        public void SwitchEditMode()
        {
            if (CurrentEditMode == EditMode.Final)
            {
                CurrentEditMode = EditMode.Auxiliary;
                _setCellValueStrategy = new AuxiliaryCellValueStrategy();
            }
            else
            {
                CurrentEditMode = EditMode.Final;
                _setCellValueStrategy = new DefinitiveCellValueStrategy();
            }
            Console.WriteLine($"Current Edit Mode: {CurrentEditMode}");
        }

        public void ToggleShowAuxiliaryNumbers()
        {
            ShowAuxiliaryNumbers = !ShowAuxiliaryNumbers;
            Console.WriteLine($"{(ShowAuxiliaryNumbers ? "Showing" : "Hiding")} Auxiliary Numbers");
        }

        public void ToggleColorInvalidNumbers()
        {
            ColorInvalidNumbers = !ColorInvalidNumbers;
            Console.WriteLine($"{(ColorInvalidNumbers ? "Showing" : "Hiding")} Invalid Number Colors");
        }
    }

    public enum EditMode
    {
        Auxiliary,
        Final
    }
}