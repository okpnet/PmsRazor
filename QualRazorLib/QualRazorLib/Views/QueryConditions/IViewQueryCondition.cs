using QualRazorLib.Presentation.Facades;

namespace QualRazorLib.Views.QueryConditions
{
    /// <summary>
    /// Viewの状態とFacade条件DTOの相互変換を担うインターフェース。
    /// Viewの状態から条件を抽出し、また外部から受け取った条件をViewの状態に復元する責務を持つ。
    /// </summary>
    /// <typeparam name="TQuery">Facadeが受け取るクエリ条件型</typeparam>
    public interface IViewQueryCondition<TQuery,TCondition> : IViewQueryExtractor<TQuery>, IViewQueryRestorer<TCondition>
    {
        /// <summary>
        /// Viewに関連付けられた値の絞り込み条件のリスト。
        /// 各条件は<see cref="IValueFilter"/>インターフェースを通じて定義される。
        /// </summary>
        IReadOnlyList<IValueFilter> ValueFilters { get; }
    }
}