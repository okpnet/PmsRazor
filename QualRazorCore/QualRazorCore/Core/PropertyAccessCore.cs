using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace QualRazorCore.Core
{
    public abstract class PropertyAccessCore:NotifyCore,INotifyPropertyChanged
    {
        public Guid Key { get; }=Guid.NewGuid();

        protected string _propertyName=string.Empty;

        public string PropertyName
        {
            get=>_propertyName;
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
    }

    public abstract class PropertyAccessCore<TModel,TResult> : PropertyAccessCore, INotifyPropertyChanged
    {

        protected Func<TModel,TResult> _getter;
        public Func<TModel, TResult> Getter
        {
            get => _getter;
            set
            {
                if(Equals(value, _getter))
                {
                    return;
                }
                _getter = value;
                OnPropertyChanged(nameof(Getter));
            }
        }

        protected Action<TModel,TResult>? _setter;

        public Action<TModel,TResult>? Setter
        {
            get => _setter;
            set
            {
                if(Equals(_setter, value))
                {
                    return;
                }
                _setter = value; 
                OnPropertyChanged(nameof(Setter));
            }
        }

        public PropertyAccessCore(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
                throw new ArgumentNullException(nameof(propertyInfo));

            _propertyName = propertyInfo.Name;
            var instance = Expression.Parameter(typeof(TModel), "instance");
            var propertyAccess = Expression.Property(instance, propertyInfo);

            _getter = Expression.Lambda<Func<TModel, TResult>>(propertyAccess, instance).Compile();
            if(propertyInfo.GetSetMethod() is not null)
            {
                _setter= Expression.Lambda<Action<TModel, TResult>>(propertyAccess, instance).Compile();
            }
        }

        public PropertyAccessCore(string propertyName,Expression<Func<TModel,TResult>> propertyExpression,Expression<Action<TModel,TResult>>? oprionExpresiion=null)
        {
            if (propertyExpression == null)
                throw new ArgumentNullException(nameof(propertyExpression));

            _propertyName = propertyName;
            _getter = propertyExpression.Compile();

            if(oprionExpresiion is not null)
            {
                _setter=oprionExpresiion.Compile();
            }
        }


    }
}
