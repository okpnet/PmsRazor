using QualRazorLib.Presentation.Facades;

namespace QualRazorLib.Views.QueryConditions
{
    /// <summary>
    /// Viewに関連付けられた値の絞り込み条件のリストを提供するインターフェースです。
    /// 各条件は<see cref="IValueFilter"/>インターフェースを通じて定義されます。
    /// </summary>
    public interface IViewQueryCondition
    {
        /// <summary>
        /// ページ
        /// </summary>
        int PageIndex { get; }
        /// <summary>
        /// Viewに関連付けられた値の絞り込み条件のリスト。
        /// 各条件は<see cref="IValueFilter"/>インターフェースを通じて定義される。
        /// </summary>
        IReadOnlyList<IValueFilter> ValueFilters { get; }
    }

    /// <summary>
    /// Viewの状態とFacade条件DTOの相互変換を担うインターフェースです。
    /// <para>
    /// ・Viewの状態（ValueFilters）からFacade層で利用するクエリ条件（TCondition型）への変換（Extract）<br/>
    /// ・外部から受け取ったクエリ条件（TCondition型）をViewの状態（ValueFilters）へ復元（RestoreFrom）<br/>
    /// を担います。
    /// </para>
    /// <typeparam name="TCondition">Facadeが受け取るクエリ条件型</typeparam>
    /// </summary>
    public interface IViewQueryCondition<TCondition> : IViewQueryCondition, IViewQueryRestorer<TCondition>, IViewQueryExtractor<TCondition>
    {

    }
}