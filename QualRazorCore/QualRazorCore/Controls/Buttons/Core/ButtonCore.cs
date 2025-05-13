using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using QualRazorCore.Core;
using QualRazorCore.Extenssions;
using QualRazorCore.Options.Configurations.Builtin;
using QualRazorCore.Options.Core;

namespace QualRazorCore.Controls.Buttons.Core
{
    public abstract class ButtonCore:OptionParameterRazorCore
    {

        [Parameter]
        public bool IsMiniButton { get; set; } = false;

        [Parameter]
        public LayerType Layer{ get; set; }

        public string CssLayer => Layer switch
        {
            LayerType.Primary => ClassDefine.Button.PRIMARY,
            LayerType.Secondary => ClassDefine.Button.SECONDARY,
            _ => ClassDefine.Button.TERTIARY,
        };


        protected abstract IOptionKey DefaultConfigOptionKey { get; }

        protected ButtonConfigOption ButtonOption
        {
            get
            {
                var key = ConfigOptionKey ?? DefaultConfigOptionKey;
                var result = ConfigOptionRegistryService.Resolve(key) as ButtonConfigOption;
                ArgumentNullException.ThrowIfNull(result);
                return result;
            }
        }

        [Parameter]
        public RenderFragment? IconContent { get; set; }
        [Parameter]
        public RenderFragment? ButtonContent { get; set; }

        protected Dictionary<string, object> MergeAttribute => HtmlAttributeHelper.MergeAttributes(
            ViewOptions?.AdditionalAttributes,
            new()
            {
                ["disabled"]=DisabledValue!,
                ["onclick"]=ButtonOption.ButtonClick,
                ["onmouseup"]=ButtonOption.ButtonUp,
                ["onmousedown"] =ButtonOption.ButtonDown
            }
            );
    }
}
