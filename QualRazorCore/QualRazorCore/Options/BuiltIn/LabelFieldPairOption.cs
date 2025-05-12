using QualRazorCore.Core;
using QualRazorCore.Options.Core;

namespace QualRazorCore.Options.BuiltIn
{
    public class LabelFieldPairOption<TModel,TProperty>:NotifyCore,IOption
    {
        protected Dictionary<string, object> _pairAdditionalAttributes = new();

        public Dictionary<string, object> PairAdditionalAttributes
        {
            get => _pairAdditionalAttributes;
            set
            {
                if (_pairAdditionalAttributes == value)
                {
                    return;
                }
                _pairAdditionalAttributes = value;
                OnPropertyChanged(nameof(PairAdditionalAttributes));
            }
        }

        protected IOptionKey _labelOptionKey = default!;
        public IOptionKey LabelOptionKey
        {
            get => _labelOptionKey;
            set
            {
                if (Equals(_labelOptionKey, value))
                {
                    return;
                }
                _labelOptionKey = value;
                OnPropertyChanged(nameof(LabelOptionKey));
            }
        }

        protected IOptionKey _fieldOptionKey = default!;
        public IOptionKey FieldOptionKey
        {
            get => _fieldOptionKey;
            set
            {
                if(Equals(_fieldOptionKey, value))
                {
                    return;
                }
                _fieldOptionKey = value;
                OnPropertyChanged(nameof(FieldOptionKey));
            }
        }

        public LabelFieldPairOption(IOptionKey labelOptionKey, IOptionKey fieldOptionKey)
        {
            _labelOptionKey = labelOptionKey;
            _fieldOptionKey = fieldOptionKey;
        }
    }
}
