using Microsoft.AspNetCore.Components;
using System;
using System.ComponentModel.DataAnnotations;

namespace DP1_Sudoku.Shared
{
    public partial class AddGameModal
    {
        public string ModalIdentifier = "addGameModal";
        public Modal Modal;

        public AddGameFormModel FormModel = new();

        [Parameter]
        public EventCallback<int> OnAddGameCompleted { get; set; }

        public async void AddGame()
        {
            // TODO: Add game implementation
            Console.WriteLine(FormModel.Name);
            Console.WriteLine(FormModel.Type);
            // ----

            await OnAddGameCompleted.InvokeAsync(1);
        }
    }

    public class AddGameFormModel
    {
        [StringLength(25, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }

        [Required]
        [RegularExpression("4x4|6x6|9x9|samurai|jigsaw", ErrorMessage = "Incorrect type")]
        public string Type { get; set; } = "";
    }
}
