using QualRazorCore.Core;
using System.ComponentModel;

namespace QualRazorCore.Controls.InputFields.Options.Core
{
    public abstract class OptionBase : NotifyCore, INotifyPropertyChanged
    {
        protected string? _placeHolder;
        public string? PlaceHolder 
        {
            get => _placeHolder;
            set
            {
                if(_placeHolder != value)
                {
                    return;
                }
                _placeHolder = value;
                OnPropertyChanged(nameof(PlaceHolder));
            }
        }

        protected Dictionary<string, object> _fieldAdditionalAttributes = new();

        public Dictionary<string, object> FieldAdditionalAttributes
        {
            get => _fieldAdditionalAttributes;
            set
            {
                if (_fieldAdditionalAttributes == value)
                {
                    return;
                }
                _fieldAdditionalAttributes = value;
                OnPropertyChanged(nameof(FieldAdditionalAttributes));
            }
        }

        protected Dictionary<string, object> _fieldLabelAdditionalAttributes = new();

        public Dictionary<string, object> FieldLabelAdditionalAttributes
        {
            get => _fieldLabelAdditionalAttributes;
            set
            {
                if (_fieldLabelAdditionalAttributes == value)
                {
                    return;
                }
                _fieldLabelAdditionalAttributes = value;
                OnPropertyChanged(nameof(FieldLabelAdditionalAttributes));
            }
        }

        protected OptionBase(string? placeHolder)
        {
            _placeHolder = placeHolder;
        }
    }
}
