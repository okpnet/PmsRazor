using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using QualRazorLib.Core;
using QualRazorLib.Helpers;

namespace QualRazorLib.Controls.Buttons
{
    public partial class QualBtutton:QualRazorComponentBase
    {
        [Parameter]
        public bool IsMiniButton { get; set; } = false;

        [Parameter]
        public LayerType Layer { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public string IconClass { get; set; } = string.Empty;

        [Parameter]
        public EventCallback<MouseEventArgs> OnClickEvent { get; set; }

        public string CssLayer { get; protected set; } = string.Empty;

        protected Dictionary<string, object> MergeDesktopAtribute => HtmlAttributeHelper.MergeAttributes(
            MeargeAttributeBase,
            new()
            {
                [HtmlAtributes.CLASS] = $"{CssClasses.Button.DESCTOP} {CssLayer}",
                [HtmlAtributes.MOUSECLICK] = OnClickEvent
            });

        protected Dictionary<string, object> MergeMobileAtribute => HtmlAttributeHelper.MergeAttributes(
            MeargeAttributeBase,
            new()
            {
                [HtmlAtributes.CLASS] = $"{CssClasses.Button.MOBILE} {CssLayer}",
                [HtmlAtributes.MOUSECLICK] = OnClickEvent
            });

        protected override void OnInitialized()
        {
            base.OnInitialized();
            CssLayer = Layer.ToCssClasses()!;
        }
    }
}
