using QualRazorCore.Options.Core;
using System.Linq.Expressions;

namespace QualRazorCore.Options.Factories
{
    public interface IExtendOptionFactory
    {
        /// <summary>
        /// 指定された型に応じた OptionBase インスタンスを生成します。
        /// サポートされていない型に対しては例外を投げるか null を返します。
        /// </summary>
        /// <param name="targetType">対象のプロパティ型</param>
        /// <returns>生成された OptionBase</returns>
        IOption? Create<TModel, TProperty>(Type targetType,Expression<Func<TModel, TProperty>> expression);
    }
}
