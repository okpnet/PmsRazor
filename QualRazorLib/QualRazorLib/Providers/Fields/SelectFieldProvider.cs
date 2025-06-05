using System.ComponentModel;

namespace QualRazorLib.Providers.Fields
{
    public class SelectFieldProvider<T> : FieldProviderCore, IInputTypeProvider, INotifyPropertyChanged
    {
        protected Func<T?, T?, bool>? _compareFunc;
        public Func<T?, T?, bool>? CompareFunc
        {
            get => _compareFunc;
            set
            {
                if(Equals(value, _compareFunc))
                {
                    return;
                }
                _compareFunc = value;
                OnPropertyChanged(nameof(CompareFunc));
            }
        }

        protected Func<T?, string>? _optionValueSelector;
        public Func<T?, string>? OptionValueSelector 
        {
            get => _optionValueSelector;
            set
            {
                if(Equals(_optionValueSelector, value))
                {
                    return;
                }
                _optionValueSelector = value;
                OnPropertyChanged(nameof(OptionValueSelector));
            }
        }
    }
}
