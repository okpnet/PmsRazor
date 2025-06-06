using Microsoft.AspNetCore.Components;
using QualRazorLib.Core;
using QualRazorLib.Helpers;

namespace QualRazorLib.Controls.LayoutControls
{
    public partial class QualHeader: QualRazorComponentBase
    {
        [Parameter]
        public EventCallback SecondaryButtonClick { get; set; }

        [Parameter]
        public EventCallback PrimaryButtonClick { get; set; }

        [Parameter]
        public RenderFragment? Title { get; set; }

        [Parameter]
        public RenderFragment? SecondaryButtonLabel { get; set; }

        [Parameter]
        public RenderFragment? PrimaryButtonLabel { get; set; }

        [Parameter]
        public string SecondaryButtonIcon { get; set; }

        [Parameter]
        public string PrimaryButtonIcon { get;set; }


        protected Dictionary<string, object> MeargeAtribute => HtmlAttributeHelper.MergeAttributes(
            MergeAttributeBase,
                new()
            );
    }
}
