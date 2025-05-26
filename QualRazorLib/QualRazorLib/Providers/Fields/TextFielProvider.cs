using BlazorCustomInput.Components;
using System.ComponentModel;

namespace QualRazorLib.Providers.Fields
{
    public class TextFielProvider : FieldProviderCore, IInputTypeProvider, INotifyPropertyChanged
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

        protected TextEditType _editType;
        public TextEditType EditType
        {
            get => _editType;
            set
            {
                if (_editType == value)
                {
                    return;
                }
                _editType = value;
                OnPropertyChanged(nameof(TextEditType));
            }
        }
    }
}
