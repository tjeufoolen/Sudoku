namespace DP1_Sudoku.Pages
{
    public partial class Index
    {
        public DisplayOptionsFormModel DisplayFormModule = new();
    }

    public class EditorModeFormModel
    {

    }

    public class DisplayOptionsFormModel
    {
        public bool ShowAuxiliaryNumbers { get; set; } = true;
        public bool ColorInvalidNumbers { get; set; } = true;
    }

}
