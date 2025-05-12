using QualRazorCore.Options.Core;

namespace QualRazorCore.Options.BuiltIn
{
    public class LabelOption:OptionBase,IOption
    {

        protected Dictionary<string, object> _labelAdditionalAttributes = new();

        public Dictionary<string, object> LabelAdditionalAttributes
        {
            get => _labelAdditionalAttributes;
            set
            {
                if (_labelAdditionalAttributes == value)
                {
                    return;
                }
                _labelAdditionalAttributes = value;
                OnPropertyChanged(nameof(LabelAdditionalAttributes));
            }
        }
    }
}
