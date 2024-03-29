﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Linq.Expressions;

namespace DP1_Sudoku.Shared.Helpers
{
    public partial class CustomValidation<TValue> : ComponentBase
    {
        [CascadingParameter] private EditContext? EditContext { get; set; }

        [Parameter] public Expression<Func<TValue>>? For { get; set; }
        [Parameter] public string? Class { get; set; }

        private FieldIdentifier _fieldIdentifier;

        protected override void OnInitialized()
        {
            if (For != null)
                _fieldIdentifier = FieldIdentifier.Create(For);

            if (EditContext != null)
                EditContext.OnValidationStateChanged += HandleValidationStateChanged;
        }

        private void HandleValidationStateChanged(object? o, ValidationStateChangedEventArgs args) => StateHasChanged();

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            if (EditContext != null)
                EditContext.OnValidationStateChanged -= HandleValidationStateChanged;
        }
    }
}
