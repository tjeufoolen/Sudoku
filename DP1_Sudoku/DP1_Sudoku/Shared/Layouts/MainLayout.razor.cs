using Microsoft.AspNetCore.Components;

namespace DP1_Sudoku.Shared.Layouts
{
    public partial class MainLayout
    {
        [Inject] public NavigationManager NavManager { get; set; }

        public Sidebar Sidebar;

        public void GoToHome()
        {
            NavManager.NavigateTo("/");
        }
    }
}
