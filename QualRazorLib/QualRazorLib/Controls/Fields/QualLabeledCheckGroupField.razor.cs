using Microsoft.AspNetCore.Components;
using QualRazorLib.Core;
using QualRazorLib.Helpers;

namespace QualRazorLib.Controls.Fields
{
    public partial class QualLabeledCheckGroupField : QualRazorComponentBase
    {
        [Parameter]
        public RenderFragment? LabelContent { get; set; }

        [Parameter]
        public RenderFragment? Checks { get; set; }

        protected Dictionary<string, object> MergeAttribute => HtmlAttributeHelper.MergeAttributes(
            MeargeAttributeBase,
            new()
            );

    }
}
