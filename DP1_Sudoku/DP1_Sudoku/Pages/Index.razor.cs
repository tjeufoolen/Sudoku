using System;

namespace DP1_Sudoku.Pages
{
    public partial class Index
    {
        public EditMode CurrentEditMode = EditMode.Final;
        public bool ShowAuxiliaryNumbers { get; private set; } = false;
        public bool ColorInvalidNumbers { get; private set; } = false;

        public void SwitchEditMode()
        {
            if (CurrentEditMode == EditMode.Final)
            {
                CurrentEditMode = EditMode.Auxiliary;
            }
            else
            {
                CurrentEditMode = EditMode.Final;
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
