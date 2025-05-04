using QualRazorCore.Controls.Conditions;
using QualRazorCore.Controls.Conditions.Helpers;
using QualRazorCore.Core;

namespace QualRazorCore.Controls.Conditions.Core
{
    public abstract class PropertyCondition : NotifyCore
    {
        public abstract object? BaseValue { get; }

        protected PropertyAccessCore _propertyAccesser = default!;
        public PropertyAccessCore PropertyAccessCore
        {
            get => _propertyAccesser;
            set
            {
                if (Equals(_propertyAccesser, value))
                {
                    return;
                }
                _propertyAccesser = value;
                OnPropertyChanged(nameof(PropertyAccessCore));
            }
        }

        protected ConditionType _conditionTypes;
        public ConditionType ConditionTypes
        {
            get => _conditionTypes;
            set
            {
                if (Equals(_conditionTypes, value))
                {
                    return;
                }
                _conditionTypes = value;
                OnPropertyChanged(nameof(ConditionTypes));
            }
        }

        public IEnumerable<ConditionType> GetConditionTypeLisst()
        {
            if (_propertyAccesser == null)
            {
                return [];
            }
            return _propertyAccesser.PropertyValueType.GetSelectableTypes();
        }
    }

    public class PropertyCondition<TValue> : PropertyCondition
    {
        public override object? BaseValue => _value;

        protected TValue _value = default!;
        public TValue Value
        {
            get => _value;
            set
            {
                if (Equals(_value, value))
                {
                    return;
                }
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }
    }
}
