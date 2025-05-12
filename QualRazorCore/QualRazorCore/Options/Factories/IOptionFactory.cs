using BlazorToaster.Core;
using QualRazorCore.Core;
using QualRazorCore.Options.Core;
using System.Linq.Expressions;

namespace QualRazorCore.Options.Factories
{
    /// <summary>
    /// 指定された型に応じた OptionBase インスタンスを生成するサービスインターフェイス。
    /// サービスに登録するOptionを生成するクラスがあるときは、このインターフェイスを継承する。
    /// </summary>
    public interface IOptionFactory
    {
        /// <summary>
        /// 指定された型に応じた OptionBase インスタンスを生成します。
        /// サポートされていない型に対しては例外を投げるか null を返します。
        /// </summary>
        /// <param name="targetType">対象のプロパティ型</param>
        /// <returns>生成された OptionBase</returns>
        IOption? Create<TRazorType>() where TRazorType:RazorCore;
    }


}