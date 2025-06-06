using Microsoft.AspNetCore.Components;
using QualRazorLib.Core;
using QualRazorLib.Helpers;

namespace QualRazorLib.Controls.LayoutControls
{
    public partial class QualSection: QualRazorComponentBase
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        protected Dictionary<string, object> MeargeAtribute => HtmlAttributeHelper.MergeAttributes(
            MergeAttributeBase,
                new()
                {
                    [HtmlAtributes.CLASS] = CssClasses.LAYOUT_SECTION
                });
    }
}
