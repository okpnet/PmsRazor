using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel;

namespace QualRazorLib.Providers.Fields
{
    public class DateFieldProvider : FieldProviderCore, IInputTypeProvider, INotifyPropertyChanged
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

        InputDateType _dateType = InputDateType.Date;
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
    }
}
