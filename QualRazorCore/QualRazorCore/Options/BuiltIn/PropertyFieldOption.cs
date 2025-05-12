using QualRazorCore.Core;
using QualRazorCore.Options.Core;
using System.ComponentModel;
using System.Linq.Expressions;

namespace QualRazorCore.Options.BuiltIn
{
    public class PropertyFieldOption<TModel, TResult> : PropertyAccessCore<TModel, TResult>, INotifyPropertyChanged,IPropertyOption<TModel, TResult>,IPropertyOption,  IFieldOption, IOption where TModel : class
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

        public PropertyFieldOption(string propertyName,
            Expression<Func<TModel, TResult>> propertyExpression) : base(propertyName, propertyExpression)
        {
        }
    }
}
