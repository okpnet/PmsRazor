using System.Collections.ObjectModel;

namespace QualRazorLib.Providers.Sources
{
    /// <summary>
    /// テーブルのデータを保持するためのインターフェイス
    /// </summary>
    /// <typeparam name="TModel">テーブルに関連付けられるデータモデルの型。</typeparam>
    public interface ITableDataProvider<TModel> : IDataProvider
    {
        /// <summary>
        /// テーブル内の総レコード数を取得します。
        /// </summary>
        int NumberOfRecords { get; }

        /// <summary>
        /// 条件に一致するレコード数を取得します。
        /// </summary>
        int NumberOfMatchedRecords { get; }

        /// <summary>
        /// テーブルの総ページ数を取得します。
        /// </summary>
        int NumberOfPage { get; }

        /// <summary>
        /// 現在のページ番号を取得します。
        /// </summary>
        int PageNumber { get; }

        /// <summary>
        /// テーブルに関連付けられたデータソースを取得します。
        /// </summary>
        ObservableCollection<TModel> Sources { get; }
    }
}