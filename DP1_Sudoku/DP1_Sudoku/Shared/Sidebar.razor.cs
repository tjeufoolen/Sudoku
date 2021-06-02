using System.Collections.Generic;

namespace DP1_Sudoku.Shared
{
    public partial class Sidebar
    {
        #region Visibility
        private bool _visible = true;
        public bool Visible
        {
            get { return _visible; }
            set
            {
                _visible = value;
                InvokeAsync(StateHasChanged);
            }
        }

        public string VisibilityClassList => Visible ? "visible" : "";
        #endregion Visibility

        // TODO: Replace with actual gametype viewmodels which contain all gamefiles per type.
        private readonly List<string> _gameTypes = new() { "4x4", "6x6", "9x9", "samurai", "jigsaw" };
    }
}
