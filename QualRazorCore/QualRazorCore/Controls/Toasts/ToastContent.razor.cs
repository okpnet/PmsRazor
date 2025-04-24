using BlazorToaster.Core;
using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.Toasts.Options;
using QualRazorCore.Core;

namespace QualRazorCore.Controls.Toasts
{
    public partial class ToastContent:RazorCore
    {
        [Inject]
        public IToastModelCollsection<ToastOption> Collection { get; set; } = default!;

        [Parameter,EditorRequired]
        public Dictionary<string, string> I18Dictionary { get; set; } = new();
    }
}
