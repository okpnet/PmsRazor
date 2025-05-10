using QualRazorCore.Core;
using System.ComponentModel;
using System.Linq.Expressions;

namespace QualRazorCore.Options.Defaults.Core
{
    public class PropertyFieldOption<TModel, TResult> : PropertyAccessCore<TModel, TResult>, INotifyPropertyChanged,IPropertyOption<TModel, TResult>,IPropertyOption, IFieldOption<TResult>, IFieldOption, IOption where TModel : class
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

        Expression<Func<TResult>> _valueExpression = default!;

        public Expression<Func<TResult>> ValueExpressions
        {
            get => _valueExpression;
            set
            {
                if (Equals(_valueExpression, value))
                {
                    return;
                }
                _valueExpression = value;
                OnPropertyChanged(nameof(ValueExpressions));
            }
        }

        public IOption FieldOption { get; set; }

        public PropertyFieldOption() : base()
        {
        }

        public PropertyFieldOption(string propertyName,
            Expression<Func<TModel, TResult>> propertyExpression) : base(propertyName, propertyExpression)
        {
        }
    }
}
