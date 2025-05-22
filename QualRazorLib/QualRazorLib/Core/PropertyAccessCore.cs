using QualRazorLib.Helpers;
using System.ComponentModel;
using System.Linq.Expressions;

namespace QualRazorLib.Core
{
    public abstract class PropertyAccessCore : NotifyCore, INotifyPropertyChanged
    {
        public Guid Key { get; } = Guid.NewGuid();

        protected string _propertyName = string.Empty;

        public string PropertyName
        {
            get => _propertyName;
            set
            {
                if (_propertyName == value)
                {
                    return;
                }
                _propertyName = value;
                OnPropertyChanged(nameof(PropertyName));
            }
        }

        public abstract Type PropertyValueType { get; }
    }

    public class PropertyAccessCore<TModel, TResult> : PropertyAccessCore, INotifyPropertyChanged
    {

        protected Func<TModel, TResult> _getter;
        public Func<TModel, TResult> Getter
        {
            get => _getter;
            set
            {
                if (Equals(value, _getter))
                {
                    return;
                }
                _getter = value;
                OnPropertyChanged(nameof(Getter));
            }
        }

        protected Action<TModel, TResult>? _setter;

        public Action<TModel, TResult>? Setter
        {
            get => _setter;
            set
            {
                if (Equals(_setter, value))
                {
                    return;
                }
                _setter = value;
                OnPropertyChanged(nameof(Setter));
            }
        }
        public override Type PropertyValueType => typeof(TResult);


        public PropertyAccessCore(Expression<Func<TModel, TResult>> propertyExpression)
        {
            ArgumentNullException.ThrowIfNull(propertyExpression);

            _propertyName = ExpressionHelper.GetPropertyPath(propertyExpression);
            _getter = ExpressionHelper.BuildGetter(propertyExpression);
            _setter = ExpressionHelper.BuildSetter(propertyExpression);
        }

        protected PropertyAccessCore(string propertyName, Expression<Func<TModel, TResult>> propertyExpression)
        {
            ArgumentNullException.ThrowIfNull(propertyExpression);

            _propertyName = propertyName;
            _getter = ExpressionHelper.BuildGetter(propertyExpression);
            _setter = ExpressionHelper.BuildSetter(propertyExpression);
        }

    }
}
