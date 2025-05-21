using Microsoft.AspNetCore.Components;
using QualRazorCore.Core;
using System.ComponentModel;
using System.Linq.Expressions;

namespace QualRazorCore.Controls.Tables.Parameters
{
    public class ColumnParameter<TModel, TResult> : PropertyAccessCore<TModel, TResult>, INotifyPropertyChanged, IColumnparameter
    {
        public ColumnParameter(Expression<Func<TModel, TResult>> propertyExpression) : base(propertyExpression)
        {
        }
    }
}
