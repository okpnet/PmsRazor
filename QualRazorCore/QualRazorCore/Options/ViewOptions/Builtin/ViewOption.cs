using QualRazorCore.Core;
using QualRazorCore.Options.Core;
using QualRazorCore.Options.ViewOptions.Core;

namespace QualRazorCore.Options.ViewOptions.Builtin
{
    public class ViewOption : NotifyCore, IViewOption
    {
        protected Dictionary<string, object> _additionalAttributes = new();

        public Dictionary<string, object> AdditionalAttributes
        {
            get => _additionalAttributes;
            set
            {
                if (_additionalAttributes == value)
                {
                    return;
                }
                _additionalAttributes = value;
                OnPropertyChanged(nameof(AdditionalAttributes));
            }
        }

        public ViewOption()
        {
            _additionalAttributes = new();
        }

        public ViewOption(Dictionary<string, object> addribute)
        {
            _additionalAttributes = addribute;
        }
    }
}
