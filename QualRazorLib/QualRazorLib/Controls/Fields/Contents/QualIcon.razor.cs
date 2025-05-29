using Microsoft.AspNetCore.Components;
using QualRazorLib.Core;
using QualRazorLib.Helpers;

namespace QualRazorLib.Controls.Fields.Contents
{
    public partial class QualIcon : QualRazorComponentBase
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public string IconClass { get; set; } = string.Empty;

        protected Dictionary<string, object> MergeAtribute => HtmlAttributeHelper.MergeAttributes(
            MeargeAttributeBase,
            new()
            {
                [HtmlAtributes.CLASS] = CssClasses.TYPE_ICON
            });

    }
}
