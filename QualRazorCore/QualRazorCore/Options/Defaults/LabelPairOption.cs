using Microsoft.Extensions.Options;
using QualRazorCore.Options.Defaults.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Options.Defaults
{
    public class LabelPairOption<TProperty>:OptionBase,IOption
    {

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

        protected IOption<TProperty> _fieldOption=default!;

        public IOption<TProperty> FieldOption
        {
            get => _fieldOption;
            set
            {
                if(Equals(_fieldOption, value))
                {
                    return;
                }
                _fieldOption = value;
                OnPropertyChanged(nameof(FieldOption));
            }
        }
    }
}
