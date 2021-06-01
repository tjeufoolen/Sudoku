using Microsoft.AspNetCore.Components;

namespace DP1_Sudoku.Shared
{
    public partial class AddGameModal
    {
        public string ModalIdentifier = "addGameModal";
        public Modal Modal;

        [Parameter]
        public EventCallback<int> OnAddGameCompleted { get; set; }

        public async void AddGame()
        {
            // TODO: Add game implementation

            await OnAddGameCompleted.InvokeAsync(1);
        }
    }
}
