using Microsoft.AspNetCore.Components.Forms;
using QualRazorCore.Options.Core;
using System.ComponentModel;

namespace QualRazorCore.Options.BuiltIn
{
    public class DateTimeOption : OptionBase, IOption, INotifyPropertyChanged
    {
        bool _isTimeSpan = false;
        public bool IsTimeSpan
        {
            get => _isTimeSpan;
            set
            {
                if (_isTimeSpan == value)
                {
                    return;
                }
                _isTimeSpan = value;
                OnPropertyChanged(nameof(IsTimeSpan));
            }
        }

        InputDateType _dateType=InputDateType.Date;
        public InputDateType DateType
        {
            get => _dateType;
            set
            {
                if (value == _dateType)
                {
                    return;
                }
                _dateType = value;
                OnPropertyChanged(nameof(DateType));
            }
        }

        string? _parseFormat;

        public string? ParseFormat
        {
            get => _parseFormat;
            set
            {
                if (value == _parseFormat)
                {
                    return;
                }
                _parseFormat = value;
                OnPropertyChanged(nameof(ParseFormat));
            }
        }

        public DateTimeOption(string? placeHolder, bool isTimeSpan, InputDateType dateType, string? parseFormat) : base(placeHolder)
        {
            _isTimeSpan = isTimeSpan;
            _dateType = dateType;
            _parseFormat = parseFormat;
        }
    }
}
