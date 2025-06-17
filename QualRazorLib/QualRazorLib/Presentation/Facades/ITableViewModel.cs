using QualRazorLib.Core;
using QualRazorLib.Providers.Sources;
using QualRazorLib.Views.QueryConditions;
using QualRazorLib.Views.States;

namespace QualRazorLib.Presentation.Facades
{
    /// <summary>
    /// テーブルビューにバインディングするためのビジネスモデルを表すインターフェースです。
    /// <para>
    /// データ（ページ数や絞り込み条件など）とロジック（データ取得・状態管理など）を併せ持ち、
    /// ユーザーが独自のテーブル用ViewModelとして実装します。
    /// </para>
    /// </summary>
    public interface ITableViewModel : IViewModel,IViewState
    {
        /// <summary>
        /// テーブルで表示可能な最大ページ数。
        /// </summary>
        int MaxNumberOfPage { get; }

        /// <summary>
        /// テーブルの絞り込み条件（Viewの状態）を管理するオブジェクト。
        /// </summary>
        IViewQueryCondition QueryCondition { get; }
    }

    /// <summary>
    /// 型指定されたテーブルビュー用ビジネスモデルのインターフェースです。
    /// <para>
    /// データの保持・取得、状態管理、パラメータ管理など、テーブル表示に必要なロジックを包括します。
    /// </para>
    /// </summary>
    /// <typeparam name="T">テーブルで扱うモデルの型</typeparam>
    public interface ITableViewModel<T> : ITableViewModel, IViewModel, IDataHolder<ITableDataProvider<T>>, IViewState
    {
    }
}