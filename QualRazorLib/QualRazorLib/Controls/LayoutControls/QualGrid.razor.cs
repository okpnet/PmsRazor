using Microsoft.AspNetCore.Components;
using QualRazorLib.Core;
using QualRazorLib.Helpers;

namespace QualRazorLib.Controls.LayoutControls
{
    public partial class QualGrid : QualRazorComponentBase
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public GridWidhStyle WidhStyle { get; set; } = GridWidhStyle.Half;

        protected string ColumnCss { get; set; } = string.Empty;

        protected Dictionary<string, object> MeargeAtribute => HtmlAttributeHelper.MergeAttributes(
        MergeAttributeBase,
            new()
            {
                [HtmlAtributes.CLASS] = ColumnCss
            });

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            ColumnCss = $"{CssClasses.COLUMN} {WidhStyle.CreateCssString()}";
        }
    }
}
