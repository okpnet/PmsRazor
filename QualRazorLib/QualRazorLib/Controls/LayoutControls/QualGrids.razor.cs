using Microsoft.AspNetCore.Components;
using QualRazorLib.Core;
using QualRazorLib.Helpers;

namespace QualRazorLib.Controls.LayoutControls
{
    public partial class QualGrids: QualRazorComponentBase
    {
        [Parameter]
        public bool IsDesktopWidthRestricted { get; set; }

        [Parameter]
        public bool IsMultiLine { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        protected Dictionary<string, object> MeargeAtribute => HtmlAttributeHelper.MergeAttributes(
            MergeAttributeBase,
                new()
                {
                    [HtmlAtributes.CLASS] = $"{CssClasses.COLUMNS} {(IsDesktopWidthRestricted ? CssClasses.DESKTOP : "")} {(IsMultiLine ? CssClasses.MULTILINE : "")}"
                });

    }
}
