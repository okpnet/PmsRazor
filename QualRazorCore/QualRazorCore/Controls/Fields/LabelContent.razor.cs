using Microsoft.AspNetCore.Components;
using QualRazorCore.Core;
using QualRazorCore.Extenssions;

namespace QualRazorCore.Controls.Fields
{
    public partial class LabelContent: RazorCore
    {
        [Parameter]
        public RenderFragment? Text { get; set; }

        protected Dictionary<string, object> MergeAttribute => HtmlAttributeHelper.MergeAttributes(
            MergeAttribute,
            new()
            {
                ["class"]= "label"
            });

    }
}
