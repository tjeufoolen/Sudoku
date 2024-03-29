﻿using Microsoft.AspNetCore.Components;

namespace DP1_Sudoku.Shared.Modals
{
    public partial class ModalComponent
    {
        [Parameter] public string? Identifier { get; set; }
        [Parameter] public EventCallback<string> IdentifierChanged { get; set; }

        public string LabelIdentifier { get => $"{Identifier}Label"; }

        [Parameter]
        public RenderFragment? Title { get; set; }

        [Parameter]
        public RenderFragment? Body { get; set; }

        [Parameter]
        public RenderFragment? Footer { get; set; }

    }
}
