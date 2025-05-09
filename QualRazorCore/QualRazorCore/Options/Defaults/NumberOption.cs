using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QualRazorCore.Options.Defaults.Core;

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
                if (_maxValue == value)
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
                if (MinValue == value)
                {
                    return;
                }
                _minValue = value;
                OnPropertyChanged(nameof(MinValue));
            }
        }
        public NumberOption():base()
        {

        }

        public NumberOption(string? placeHolder, bool isComma, int numberOfDigit, decimal? maxValue, decimal? minValue) : this()
        {
            _p = placeHolder;
            _isComma = isComma;
            _numberOfDigit = numberOfDigit;
            _maxValue = maxValue;
            _minValue = minValue;
        }
    }
}
