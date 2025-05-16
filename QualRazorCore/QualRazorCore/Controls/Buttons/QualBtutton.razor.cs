using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using QualRazorCore.Core;
using QualRazorCore.Extenssions;

namespace QualRazorCore.Controls.Buttons
{
    public partial class QualBtutton:RazorCore
    {
        [Parameter]
        public bool IsMiniButton { get; set; } = false;

        protected LayerType _layerType;
        [Parameter]
        public LayerType Layer { get; set; }

        [Parameter]
        public RenderFragment? ButtonContent { get; set; }

        [Parameter]
        public string IconClass { get; set; } = string.Empty;

        [Parameter]
        public EventCallback<MouseEventArgs> OnClickEvent { get; set; }

        public string CssLayer { get;protected set; }=string.Empty;

        protected Dictionary<string, object> MergeDesktopAtribute => HtmlAttributeHelper.MergeAttributes(
            MeargeAttributeBase,
            new()
            {
                ["class"] = $"button is-hidden-touch {CssLayer}",
                ["onclick"]=OnClickEvent
            });

        protected Dictionary<string, object> MergeMobileAtribute => HtmlAttributeHelper.MergeAttributes(
            MeargeAttributeBase,
            new()
            {
                ["class"] = $"button is-fullwidth is-hidden-desktop {CssLayer}",
                ["onclick"] = OnClickEvent
            });

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (_layerType != Layer)
            {
                _layerType = Layer;
                CssLayer=Layer switch
                {
                    LayerType.Primary => "is-primary",
                    LayerType.Secondary => "is-primary is-outlined",
                    _ => "is-text",
                };
            }
        }
    }
}
