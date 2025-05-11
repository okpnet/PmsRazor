using QualRazorCore.Options.Core;

namespace QualRazorCore.Options.BuiltIn
{
    public class LabelPairOption<TProperty>:OptionBase,IOption
    {

        protected Dictionary<string, object> _fieldLabelAdditionalAttributes = new();

        public Dictionary<string, object> FieldLabelAdditionalAttributes
        {
            get => _fieldLabelAdditionalAttributes;
            set
            {
                if (_fieldLabelAdditionalAttributes == value)
                {
                    return;
                }
                _fieldLabelAdditionalAttributes = value;
                OnPropertyChanged(nameof(FieldLabelAdditionalAttributes));
            }
        }

        protected Dictionary<string, object> _fieldContainerAdditionalAttributes = new();

        public Dictionary<string, object> FieldContainerAdditionalAttributes
        {
            get => _fieldContainerAdditionalAttributes;
            set
            {
                if (_fieldContainerAdditionalAttributes == value)
                {
                    return;
                }
                _fieldContainerAdditionalAttributes = value;
                OnPropertyChanged(nameof(FieldContainerAdditionalAttributes));
            }
        }
    }
}
