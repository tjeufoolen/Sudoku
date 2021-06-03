using DP1_Sudoku.BusinessLogic;
using DP1_Sudoku.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DP1_Sudoku.Shared
{
    public partial class Sidebar
    {
        [Inject] public IPuzzleObjectFactory? PuzzleFactory { get; set; }
        [Inject] public NavigationManager? NavManager { get; set; }

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

        private List<PuzzleObject> _puzzles = new();


        protected override async Task OnInitializedAsync()
        {
            if (PuzzleFactory != null)
            {
                _puzzles = await PuzzleFactory.LoadAll();
            }

        }

        public void NavigateToGame(string name, string extension)
        {
            NavManager?.NavigateTo($"/game/{extension}/{name}");
        }
    }
}
