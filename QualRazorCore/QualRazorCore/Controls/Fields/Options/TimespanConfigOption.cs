using BlazorCustomInput.Components;
using QualRazorCore.Options.Configurations.Builtin;
using QualRazorCore.Options.Core;
using System.ComponentModel;

namespace QualRazorCore.Controls.Fields.Options
{
    public class TimespanConfigOption : FieldOpionBase,  INotifyPropertyChanged
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

        Unit _unit = Unit.Hour | Unit.Min;
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

    }
}
