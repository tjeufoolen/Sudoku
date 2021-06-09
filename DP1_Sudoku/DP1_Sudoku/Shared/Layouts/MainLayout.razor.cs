using Microsoft.AspNetCore.Components;

namespace DP1_Sudoku.Shared.Layouts
{
    public partial class MainLayout
    {
        [Inject] public NavigationManager? NavManager { get; set; }

        public SidebarComponent? Sidebar;

        public void GoToHome()
        {
            NavManager?.NavigateTo("/");
        }

        public void ToggleVisibility()
        {
            if (Sidebar != null)
            {
                Sidebar.Visible = !Sidebar.Visible;
            }
        }
    }
}
