using Microsoft.AspNetCore.Components;
using QualRazorLib.Core;
using QualRazorLib.Helpers;

namespace QualRazorLib.Controls.Fields.Contents
{
    public partial class QualFieldContainer:QualRazorComponentBase
    {
        [Parameter]
        public bool IsDesktopWidthRestricted { get; set; }

        [Parameter]
        public bool IsMultiLine { get; set; }

        [Parameter]
        public GridWidhStyle WidhStyle { get; set; } = GridWidhStyle.Half;

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        protected string ColumnCss { get; set; } = string.Empty;

        protected Dictionary<string, object> MergeAttribute => HtmlAttributeHelper.MergeAttributes(
                MergeAttributeBase,
                new()
                {
                    [HtmlAtributes.CLASS] = $"{CssClasses.COLUMNS} {(IsDesktopWidthRestricted?CssClasses.DESKTOP:"")} {(IsMultiLine?CssClasses.MULTILINE:"")}"
                });

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            ColumnCss = $"{CssClasses.COLUMN} {WidhStyle.CreateCssString()}";
        }
    }
}
