using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Options.Core
{
    public abstract class FieldOption:OptionBase
    {
        protected string? _placeHolder;
        public string? PlaceHolder
        {
            get => _placeHolder;
            set
            {
                if (_placeHolder != value)
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
    }
}
