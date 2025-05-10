using QualRazorCore.Options.Defaults.Core;
using System.ComponentModel;

namespace QualRazorCore.Options.Defaults
{
    public class NumberOption<T> : FieldOption, IOption, INotifyPropertyChanged
    {
        bool _isComma=false;
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

        int _numberOfDigit=0;
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
                if (Equals(MinValue,value))
                {
                    return;
                }
                _minValue = value;
                OnPropertyChanged(nameof(MinValue));
            }
        }

        public NumberOption(string? placeHolder, bool isComma, int numberOfDigit, decimal? maxValue, decimal? minValue) 
        {
            _placeHolder = placeHolder;
            _isComma = isComma;
            _numberOfDigit = numberOfDigit;
            _maxValue = maxValue;
            _minValue = minValue;
        }
    }
}
