using BlazorCustomInput.Components;
using QualRazorCore.Options.Defaults.Core;
using System.ComponentModel;

namespace QualRazorCore.Options.Defaults
{
    public class StringOption : FieldOption, IOption, INotifyPropertyChanged
    {
        bool _isMultiLine;
        public bool IsMutiLine
        {
            get => _isMultiLine;
            set
            {
                if (_isMultiLine == value)
                {
                    return;
                }
                _isMultiLine = value;
                OnPropertyChanged(nameof(IsMutiLine));
            }
        }

        public virtual TextEditType TextEditType => TextEditType.Text;

        public StringOption(string? placeHolder, bool isMultiLine) : base()
        {
            _placeHolder = placeHolder;
            _isMultiLine = isMultiLine;
        }
    }
}
