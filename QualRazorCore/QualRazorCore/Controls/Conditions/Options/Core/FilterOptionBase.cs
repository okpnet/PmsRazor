using QualRazorCore.Controls.Conditions.Core;
using QualRazorCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Conditions.Options.Core
{
    public abstract class FilterOptionBase:NotifyCore
    {
        PropertyCondition _propertyConditions=default!;

        public PropertyCondition PropertyConditions
        {
            get => _propertyConditions;
            set
            {
                if (Equals(_propertyConditions , value))
                {
                    return; 
                }
                _propertyConditions = value;
                OnPropertyChanged(nameof(PropertyConditions));
            }
        }


        protected Dictionary<string, object> _propertylabelAdditionalAttributes = new();

        public Dictionary<string, object> PropertyLabelAdditionalAttributes
        {
            get => _propertylabelAdditionalAttributes;
            set
            {
                if (_propertylabelAdditionalAttributes == value)
                {
                    return;
                }
                _propertylabelAdditionalAttributes = value;
                OnPropertyChanged(nameof(PropertyLabelAdditionalAttributes));
            }
        }
    }
}
