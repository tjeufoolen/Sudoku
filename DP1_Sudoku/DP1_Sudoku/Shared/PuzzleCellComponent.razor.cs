using DP1_Sudoku.BusinessLogic;
using DP1_Sudoku.Pages.Game;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace DP1_Sudoku.Shared
{
    public partial class PuzzleCellComponent
    {
        [Parameter] public Cell? Cell { get; set; }
        [Parameter] public EventCallback<Cell?> CellChanged { get; set; }
        [CascadingParameter] public PuzzleComponent? Parent { get; set; }
        [CascadingParameter] public PuzzleDisplaySettings? DisplaySettings { get; set; }

        public bool IsSelected => Parent?.SelectedCellComponent == this;
        public bool IsBlocked => !Cell?.IsDrawable ?? false;

        public void Select()
        {
            if (Parent != null && Cell != null && Cell.IsSelectable)
                Parent.SelectedCellComponent = this;
        }

        private bool ShowAuxiliaryNumbers()
        {
            if (Cell?.CurrentValue != null) return false;
            return DisplaySettings == null || DisplaySettings.ShowAuxiliaryNumbers;
        }

        private bool DisplayInvalidColor()
        {
            if (Cell == null) return false;
            if (DisplaySettings == null) return false;
            if (DisplaySettings.ColorInvalidNumbers == false) return false;
            return !Cell.IsValid;
        }

        private string BorderClassList()
        {
            List<string> classes = new();

            if (Cell != null)
            {
                var subgroup = Parent?.Board?.SubGroups.FirstOrDefault(s => s.Contains(Cell));

                if (subgroup != null)
                {
                    string[] properties = new string[] { "Top", "Right", "Bottom", "Left" };
                    foreach (var property in properties)
                    {
                        Cell? propertyValue = Cell.GetType().GetProperty(property)?.GetValue(Cell, null) as Cell;
                        if (propertyValue == null || !subgroup.Contains(propertyValue)) classes.Add($"border-{property.ToLower()}");
                    }
                }
            }

            return string.Join(" ", classes);
        }
    }
}
