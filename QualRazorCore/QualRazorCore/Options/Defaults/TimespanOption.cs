using BlazorCustomInput.Components;
using QualRazorCore.Options.Defaults.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Options.Defaults
{
    public class TimespanOption : OptionBase, IOption, INotifyPropertyChanged
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

        Unit _unit;
        public Unit Unit
        {
            get => _unit;
            set
            {
                if (_unit == value)
                {
                    return;
                }
                _unit = value;
                OnPropertyChanged(nameof(Unit));
            }
        }

        public TimespanOption(string? placeHolder, bool isComma, int numberOfDigit, decimal? maxValue, Unit unit) : base()
        {
            _isComma = isComma;
            _numberOfDigit = numberOfDigit;
            _maxValue = maxValue;
            _unit = unit;
        }
    }
}
