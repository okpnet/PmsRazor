using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using QualRazorCore.Core;

namespace QualRazorCore.Controls.Buttons.Core
{
    public abstract class ButtonCore:RazorCore
    {
        bool _isMini;

        public bool IsMiniButton
        {
            get => _isMini;
            set
            {
                if(_isMini == value)
                {
                    return;
                }
                _isMini = value;
                OnPropertyChanged(nameof(IsMiniButton));
            }
        }

        LayerType _layerType;
        public LayerType Layer
        {
            get => _layerType;
            set
            {
                if( _layerType == value)
                {
                    return;
                }
                _layerType = value;
                OnPropertyChanged(nameof(Layer));
            }
        }

        public string CssLayer => _layerType switch
        {
            LayerType.Primary => ClassDefine.Button.PRIMARY,
            LayerType.Secondary => ClassDefine.Button.SECONDARY,
            _ => ClassDefine.Button.TERTIARY,
        };

        [Parameter]
        public EventCallback<MouseEventArgs> ButtonUp { get; set; }
        [Parameter]
        public EventCallback ButtonClick { get; set; }
        [Parameter]
        public EventCallback<MouseEventArgs> ButtonDown { get; set; }
        [Parameter]
        public RenderFragment? IconContent { get; set; }
        [Parameter]
        public RenderFragment? ButtonContent { get; set; }
    }
}
