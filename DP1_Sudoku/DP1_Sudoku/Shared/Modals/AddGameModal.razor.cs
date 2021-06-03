using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.ComponentModel.DataAnnotations;

namespace DP1_Sudoku.Shared.Modals
{
    public partial class AddGameModal
    {
        [Parameter] public EventCallback<int> OnAddGameCompleted { get; set; }
        public Modal? Modal;
        public string ModalIdentifier = "addGameModal";
        public AddGameFormModel FormModel = new();

        public void OnInputFileChange(InputFileChangeEventArgs e) => this.FormModel.File = e.File;

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
        [StringLength(25, ErrorMessage = "Name is too long.")] //TODO: what the game name limit should be.
        public string? Name { get; set; }

        [Required]
        [RegularExpression("4x4|6x6|9x9|samurai|jigsaw", ErrorMessage = "Incorrect type.")] //TODO: Load the options from somewhere instead of writing them hard
        public string Type { get; set; } = "";

        [Required]
        [FileValidation]
        public IBrowserFile? File { get; set; }
    }

    public class FileValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            AddGameFormModel? _model = validationContext.ObjectInstance as AddGameFormModel;

            if (_model?.File?.Size > 1000000) //TODO: Determine what the file size upload limit should be.
            {
                if (validationContext.MemberName != null)
                {
                    return new ValidationResult("This file is too powerfull, the max filesize is 1MB.", new[] { validationContext.MemberName });
                }
            }

            return ValidationResult.Success!;
        }
    }
}
