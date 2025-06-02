using System.ComponentModel;

namespace QualRazorLib.Providers.Fields
{
    public class NumberFieldProvider<T> : FieldProviderCore, IInputTypeProvider, INotifyPropertyChanged
    {
        public override FieldDataType InputType => FieldDataType.Number;
        bool _isComma = false;
        public bool IsComma
        {
            get => _isComma;
            set
            {
                if (_isComma == value)
                {
                    return;
                }
                _isComma = value;
                OnPropertyChanged(nameof(IsComma));
            }
        }

        int _numberOfDigit = 0;
        public int NumberOfDigit
        {
            get => _numberOfDigit;
            set
            {
                if (_numberOfDigit == value)
                {
                    return;
                }
                _numberOfDigit = value;
                OnPropertyChanged(nameof(NumberOfDigit));
            }
        }

        decimal? _maxValue;
        public decimal? MaxValue
        {
            get => _maxValue;
            set
            {
                if (Equals(_maxValue, value))
                {
                    return;
                }
                _maxValue = value;
                OnPropertyChanged(nameof(MaxValue));
            }
        }

        decimal? _minValue;
        public decimal? MinValue
        {
            get => _minValue;
            set
            {
                if (Equals(MinValue, value))
                {
                    return;
                }
                _minValue = value;
                OnPropertyChanged(nameof(MinValue));
            }
        }
    }
}
