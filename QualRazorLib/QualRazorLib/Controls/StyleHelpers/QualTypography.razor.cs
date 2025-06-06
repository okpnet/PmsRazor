using Microsoft.AspNetCore.Components;
using QualRazorLib.Core;
using QualRazorLib.Helpers;

namespace QualRazorLib.Controls.StyleHelpers
{
    public partial class QualTypography : QualRazorComponentBase
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public TextSizeType SizeType { get; set; } = TextSizeType.Normal;

        [Parameter]
        public TextBoldType BoldType { get; set; } = TextBoldType.None;


        protected Dictionary<string, object> MergeAttribute => HtmlAttributeHelper.MergeAttributes(
            MergeAttributeBase,
            new()
            {
                [HtmlAtributes.CLASS] = $"{SizeType.CreateCssString()} {BoldType.CreateCssString()}"
            }
            );
    }
}
