using QualRazorLib.Presentation.Facades;

namespace QualRazorLib.Views.QueryConditions
{
    /// <summary>
    /// モデル（DTO等）とビューの絞り込み条件（<see cref="IValueFilter"/>のリスト）を
    /// 相互に変換するためのデフォルト実装クラスです。
    /// <para>
    /// ・Viewの状態（ValueFilters）からFacade層で利用するクエリ条件（TQuery型）への変換（Extract）<br/>
    /// ・外部から受け取ったクエリ条件をViewの状態（ValueFilters）へ復元（RestoreFrom）<br/>
    /// を委譲されたデリゲート（extractor/restorer）で実現します。
    /// </para>
    /// </summary>
    /// <typeparam name="TQuery">Facade層で利用するクエリ条件DTOの型</typeparam>
    public class DefaultViewQueryCondition<TQuery> : IViewQueryCondition<TQuery, IReadOnlyList<IValueFilter>> where TQuery : class
    {
        /// <summary>
        /// Viewの状態（IValueFilterリスト）からTQuery型の条件DTOを生成するデリゲート。
        /// </summary>
        protected readonly Func<IReadOnlyList<IValueFilter>, TQuery> _extractor = default!;

        /// <summary>
        /// 外部から受け取ったIValueFilterリストをViewの状態に復元するデリゲート。
        /// </summary>
        protected readonly Action<IReadOnlyList<IValueFilter>> _restorer = default!;

        /// <summary>
        /// Viewに紐づく絞り込み条件のリスト。
        /// </summary>
        protected List<IValueFilter> _valueFilters = [];

        /// <summary>
        /// Viewに紐づく絞り込み条件のリスト（読み取り専用）。
        /// </summary>
        public IReadOnlyList<IValueFilter> ValueFilters => _valueFilters;

        /// <summary>
        /// 変換用デリゲートを指定してインスタンスを生成します。
        /// </summary>
        /// <param name="extractor">Viewの状態からTQuery型条件DTOを生成するデリゲート</param>
        /// <param name="restorer">TQuery型条件DTOからViewの状態を復元するデリゲート</param>
        public DefaultViewQueryCondition(Func<IReadOnlyList<IValueFilter>, TQuery> extractor, Action<IReadOnlyList<IValueFilter>> restorer)
        {
            _extractor = extractor;
            _restorer = restorer;
        }

        /// <summary>
        /// Viewの状態（ValueFilters）からFacade層向けのクエリ条件DTOを生成します。
        /// </summary>
        /// <returns>TQuery型の条件DTO</returns>
        public TQuery Extract() => _extractor(ValueFilters);

        /// <summary>
        /// 外部から受け取った絞り込み条件リストをViewの状態に復元します。
        /// </summary>
        /// <param name="condition">IValueFilterリスト</param>
        public void RestoreFrom(IReadOnlyList<IValueFilter> condition) => _restorer(condition);
    }
}