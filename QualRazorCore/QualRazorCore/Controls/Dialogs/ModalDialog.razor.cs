using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.Dialogs.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Dialogs
{
    public partial class ModalDialog
    {
        [Parameter]
        public RenderFragment? DialogContents { get; set; }

        [Parameter]
        public string DialogTitle { get; set; } = string.Empty;

        [Parameter,EditorRequired]
        public ModalDialogModel DialogModel { get; set; } = default!;
    }
}
