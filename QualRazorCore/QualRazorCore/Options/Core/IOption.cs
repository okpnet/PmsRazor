using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Options.Core
{
    public interface IOption
    {
    }
    public interface IOption<TModel,TProperty>:IOption
    {
        TModel BindModels { get; set; }
        Expression<Func<TProperty>> ValueExpressions { get; set; }
        Action<TProperty> ValueChanged { get; }
    }
}
