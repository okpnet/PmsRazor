using QualRazorLib.Providers.Sources;
using QualRazorLib.Views.QueryConditions;

namespace QualRazorLib.Presentation.Facades
{
    /// <summary>
    /// テーブルビューにバインディングするための基底クラスです。
    /// <para>
    /// このクラスは、テーブル表示に必要なデータ（<see cref="ITableDataProvider{T}"/>）や状態管理（ローディング・エラー）、
    /// 絞り込み条件（<see cref="IViewQueryCondition"/>）などの共通実装を提供します。
    /// </para>
    /// <para>
    /// 必ずしも継承する必要はありませんが、継承することで主要なプロパティや状態管理メソッド（SetLoading, SetError, ClearError, Resetなど）を
    /// オーバーライドするだけでテーブル用ViewModelの実装が簡単になります。
    /// </para>
    /// <typeparam name="T">テーブルで扱うモデルの型</typeparam>
    /// </summary>
    public abstract class TableViewModelBase<T> : ITableViewModel<T>, ITableViewModel where T : class
    {
        /// <summary>
        /// テーブルデータのプロバイダー。
        /// </summary>
        public abstract ITableDataProvider<T> Data { get; protected set; }

        /// <summary>
        /// データ取得中かどうかの状態。
        /// </summary>
        public bool IsLoading { get; protected set; } = false;

        /// <summary>
        /// エラーが発生しているかどうかの状態。
        /// </summary>
        public bool HasError { get; protected set; } = false;

        /// <summary>
        /// エラーメッセージ。
        /// </summary>
        public string ErrorMessage { get; protected set; } = string.Empty;

        /// <summary>
        /// テーブルで表示可能な最大ページ数。
        /// </summary>
        public int MaxNumberOfPage { get; }

        /// <summary>
        /// テーブルの絞り込み条件（Viewの状態）を管理するオブジェクト。
        /// </summary>
        public IViewQueryCondition QueryCondition { get;protected set; } = default!;

        protected TableViewModelBase(int maxNumberOfPage)
        {
            MaxNumberOfPage = maxNumberOfPage;
        }
        /// <summary>
        /// テーブルの絞り込み条件（Viewの状態）を管理するオブジェクトをデフォルトで初期化します。
        /// </summary>
        /// <typeparam name="TCondition"></typeparam>
        /// <param name="extractor"></param>
        /// <param name="restorer"></param>
        public void SetQueryCondition<TCondition>(Func<IReadOnlyList<IValueFilter>, TCondition> extractor, Func<TCondition, IReadOnlyList<IValueFilter>> restorer) where TCondition : class
        {
            QueryCondition = new DefaultViewQueryCondition<TCondition>(extractor, restorer);
        }

        /// <summary>
        /// 最大ページ数と絞り込み条件を指定して初期化します。
        /// </summary>
        /// <param name="maxNumberOfPage">最大ページ数</param>
        /// <param name="queryCondition">絞り込み条件オブジェクト</param>
        protected TableViewModelBase(int maxNumberOfPage, IViewQueryCondition queryCondition)
        {
            MaxNumberOfPage = maxNumberOfPage;
            QueryCondition = queryCondition;
        }

        /// <summary>
        /// エラー状態をクリアします。
        /// </summary>
        public virtual void ClearError()
        {
            HasError = false;
            ErrorMessage = string.Empty;
        }

        /// <summary>
        /// データの読み込み処理を実装します（派生クラスで必須）。
        /// </summary>
        public abstract Task LoadAsync();

        /// <summary>
        /// 状態をリセットします。エラー状態もクリアされます。
        /// </summary>
        public virtual void Reset()
        {
            ClearError();
        }

        /// <summary>
        /// エラー状態を設定します。
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        public virtual void SetError(string message)
        {
            HasError = true;
            ErrorMessage = message;
        }

        /// <summary>
        /// ローディング状態を設定します。
        /// </summary>
        /// <param name="isLoading">ローディング中かどうか</param>
        public virtual void SetLoading(bool isLoading)
        {
            IsLoading = isLoading;
        }

        /// <summary>
        /// データの送信や更新処理を実装します（派生クラスで必須）。
        /// </summary>
        public abstract Task SubmitAsync();
    }
}