using Microsoft.AspNetCore.Components;
using QualRazorCore.Core;
using QualRazorCore.Extenssions;

namespace QualRazorCore.Controls.Fields
{
    public partial class IconContent:RazorCore
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public string IconClass { get; set; } = string.Empty;

        protected Dictionary<string, object> MergeAtribute => HtmlAttributeHelper.MergeAttributes(
            MeargeAttributeBase,
            new()
            {
                ["class"]="icon",
                ["disabled"]=DisabledValue!
            });
    }
}
