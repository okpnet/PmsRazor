using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.Buttons;
using QualRazorCore.Controls.Dialogs.Options;
using QualRazorCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Dialogs
{
    public partial class ModalDialog:RazorCore
    {   
        protected TaskCompletionSource<bool>? _taskCompletionSource = default!;

        [Parameter]
        public RenderFragment? DialogContents { get; set; }

        [Parameter]
        public string DialogTitle { get; set; } = string.Empty;

        [Parameter,EditorRequired]
        public ModalDialogOption Options { get; set; } = default!;

        [Parameter]
        public RenderFragment? PrimaryButtonContent { get; set; }
        [Parameter]
        public RenderFragment? PrimaryButtonIconContent { get; set; }

        [Parameter]
        public RenderFragment? SecondaryButtonContent { get; set; }
        [Parameter]
        public RenderFragment? SecondaryButtonIconContent { get; set; }

        [Parameter]
        public RenderFragment? TertiaryButtonContent { get; set; }

        [Parameter]
        public RenderFragment? TertiaryButtonIconContent { get; set; }

        [Parameter]
        public bool PrimarySubmitButton { get; set; }

        protected async Task OnClose() => await InvokeAsync(()=> Options.CloseDialog(DialogResult.Close));

        protected async Task OnPrimaryClick() => await InvokeAsync(() => Options.CloseDialog(DialogResult.Primary));

        protected async Task OnSecondaryClick() => await InvokeAsync(() => Options.CloseDialog(DialogResult.Secondary));

        protected async Task OnTertiaryClick() => await InvokeAsync(() => Options.CloseDialog(DialogResult.Tertiary));

    }
}
