using Microsoft.AspNetCore.Components;
using QualRazorCore.Core;
using System.ComponentModel;
using System.Linq.Expressions;

namespace QualRazorCore.Controls.Tables.Parameters
{
    public class ColumnParameter<TModel, TResult> : PropertyAccessCore<TModel, TResult>, INotifyPropertyChanged, IColumnParamter
    {

        public RenderFragment? HeaderContent { get; }
        public ColumnParameter(RenderFragment? headerContent,Expression<Func<TModel, TResult>> propertyExpression) : base(propertyExpression)
        {
            HeaderContent = headerContent;
        }
    }
}
