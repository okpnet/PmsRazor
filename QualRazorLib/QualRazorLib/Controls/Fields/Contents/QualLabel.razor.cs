using Microsoft.AspNetCore.Components;
using QualRazorLib.Core;
using QualRazorLib.Helpers;

namespace QualRazorLib.Controls.Fields.Contents
{
    public partial class QualLabel : QualRazorComponentBase
    {
        [Parameter]
        public RenderFragment? Text { get; set; }

        protected Dictionary<string, object> MergeAttribute => HtmlAttributeHelper.MergeAttributes(
            MergeAttribute,
            new()
            {
                [HtmlAtributes.CLASS] = CssClasses.LABEL
            });
    }
}
