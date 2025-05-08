using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QualRazorCore.Controls.InputFields.Options.Core;
using QualRazorCore.Options;

namespace QualRazorCore.Controls.InputFields.Options
{
    public class NumberOption<T>:OptionBase, IOption, INotifyPropertyChanged
    {
        bool _isComma;
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

        int _numberOfDigit;
        public int NumberOfDigit
        {
            get => _numberOfDigit;
            set
            {
                if(_numberOfDigit == value)
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

        public NumberOption(string? placeHolder, bool isComma, int numberOfDigit, decimal? maxValue, decimal? minValue):base(placeHolder)
        {
            _isComma = isComma;
            _numberOfDigit = numberOfDigit;
            _maxValue = maxValue;
            _minValue = minValue;
        }
    }
}
