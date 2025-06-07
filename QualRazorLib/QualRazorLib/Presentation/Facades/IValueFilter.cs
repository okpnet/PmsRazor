using QualRazorLib.Views.QueryConditions;

namespace QualRazorLib.Presentation.Facades
{
    /// <summary>
    /// モデルや値の絞り込み条件を表すインターフェイス
    /// </summary>
    public interface IValueFilter
    { }

    /// <summary>
    /// ジェネリック型のモデルと値に基づく絞り込み条件を表すインターフェイス
    /// </summary>
    /// <typeparam name="TModel">絞り込み対象のモデルの型</typeparam>
    /// <typeparam name="TValue">絞り込み対象の値の型</typeparam>
    public interface IValueFilter<TModel, TValue> : IValueFilter
    {
        /// <summary>
        /// モデルから値を取得するための式
        /// </summary>
        Func<TModel, TValue> Getter { get; }

        /// <summary>
        /// モデルから取得した値に対する条件のリスト
        /// </summary>
        IReadOnlyList<ConditionEntry<TValue>> Conditions { get; }
    }

    /// <summary>
    /// 条件と値の組み合わせを表すレコード
    /// </summary>
    /// <typeparam name="TValue">条件に関連付けられる値の型</typeparam>
    /// <param name="Type">条件の種類を表す<see cref="ConditionType"/></param>
    /// <param name="Values">条件に関連付けられる値のリスト</param>
    public record ConditionEntry<TValue>(ConditionType Type, IList<TValue> Values);
}