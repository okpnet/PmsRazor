using BlazorCustomInput.Components;
using System.ComponentModel;

namespace QualRazorCore.Controls.Fields.Options
{
    public class TextConfigOption : FieldOpionBase, INotifyPropertyChanged
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

        protected TextEditType _textEditType = TextEditType.Text;
        public TextEditType TextEditType
        {
            get => _textEditType;
            set
            {
                if (_textEditType == value)
                {
                    return;
                }
                _textEditType = value;
                OnPropertyChanged(nameof(TextEditType));
            }
        }

    }
}
