using Microsoft.AspNetCore.Components;
using QualRazorLib.Core;
using QualRazorLib.Helpers;

namespace QualRazorLib.Controls.Fields.Contents
{
    public partial class QualFields: QualRazorComponentBase
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        protected Dictionary<string, object> MergeAttribute => HtmlAttributeHelper.MergeAttributes(
            MergeAttributeBase,
            new()
            {
                [HtmlAtributes.CLASS] = CssClasses.FIELD
            });
    }
}
