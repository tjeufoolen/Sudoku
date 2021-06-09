using DP1_Sudoku.BusinessLogic.Interfaces;
using DP1_Sudoku.BusinessLogic.Strategies.CellValueStrategies;
using Microsoft.AspNetCore.Components;

namespace DP1_Sudoku.Shared
{
    public partial class PuzzleCellInputComponent
    {
        [Parameter] public int? MaxValidCellValue { get; set; }
        [Parameter] public ICellValueStrategy? ValueStrategy { get; set; }
        [Parameter] public EventCallback<ICellValueStrategy?> ValueStrategyChanged { get; set; }
        [Parameter] public EventCallback<int> ValueChanged { get; set; }
        [Parameter] public bool? IsDisabled { get; set; }
        private ICellValueStrategy? _valueStrategy;
        private int _value;
        private EditMode _currentEditMode = EditMode.Final;

        protected override void OnParametersSet()
        {
            _valueStrategy = ValueStrategy;
            base.OnParametersSet();
        }

        private void SwitchEditMode()
        {
            if (_currentEditMode == EditMode.Final)
            {
                _currentEditMode = EditMode.Help;
                _valueStrategy = new HelpCellValueStrategy();
            }
            else
            {
                _currentEditMode = EditMode.Final;
                _valueStrategy = new CellValueStrategy();
            }

            ValueStrategyChanged.InvokeAsync(_valueStrategy);
        }

        private void InputHasChanged(string? input)
        {
            _ = int.TryParse(input, out int parsedValue);
            _value = parsedValue;
        }

        private void EnterValue() => ValueChanged.InvokeAsync(_value);
    }


    public enum EditMode
    {
        Help,
        Final
    }
}