using Microsoft.AspNetCore.Components.Forms;
using QualRazorCore.Controls.Forms;
using QualRazorCore.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Fields.Options
{
    public class PropertyValueOption<TModel, TResult> : PropertyAccessCore<TModel, TResult>, INotifyPropertyChanged, IPropertyValueOption where TModel : class
    {
        EditContext _editContext;
        public EditContext CascadingEditContext
        {
            get => _editContext;
            set
            {
                if (Equals(_editContext, value))
                {
                    return;
                }
                _editContext = value;
                OnPropertyChanged(nameof(CascadingEditContext));
            }
        }
        public TResult BindValue
        {
            get => Getter(ChangeObject());
            set
            {
                if(Setter is null)
                {
                    return;
                }
                Setter(ChangeObject(), value);
            }
        }

        public PropertyValueOption(string propertyName,
            Expression<Func<TModel, TResult>> propertyExpression, 
            Expression<Action<TModel, TResult>>? oprionExpresiion = null) : base(propertyName, propertyExpression, oprionExpresiion)
        {

        }

        private TModel ChangeObject()
        {
            if (_editContext.Model is not TModel model)
            {
                throw new InvalidCastException($"Property model of EditContext cannot be caset '{typeof(TModel).Name}'");
            }
            return model;
        }
    }
}
