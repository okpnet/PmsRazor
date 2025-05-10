using System.Diagnostics.Metrics;
using System.Linq.Expressions;

namespace QualRazorCore.Options
{
    public interface IFieldOption : IOption
    {
        IOption FieldOption { get; set; }
    }

    public interface IFieldOption<TProperty>: IFieldOption
    {
        Expression<Func<TProperty>> ValueExpressions { get; set; }

    }
}