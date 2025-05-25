using System.Collections;

namespace QualRazorLib.Core
{
    /// <summary>
    /// IDisposable オブジェクトのコレクションを管理し、一括で破棄できるコレクションです。
    /// </summary>
    public class DisposableCollection : ICollection<IDisposable>, IDisposable
    {
        // 管理対象の IDisposable オブジェクトのリスト
        private List<IDisposable> _list = [];

        /// <summary>
        /// コレクション内の要素数を取得します。
        /// </summary>
        public int Count => _list.Count;

        /// <summary>
        /// コレクションが読み取り専用かどうかを示します（常に true）。
        /// </summary>
        public bool IsReadOnly => true;

        /// <summary>
        /// IDisposable オブジェクトをコレクションに追加します。
        /// </summary>
        /// <param name="item">追加する IDisposable オブジェクト</param>
        public void Add(IDisposable item)
        {
            _list.Add(item);
        }

        /// <summary>
        /// コレクション内のすべての IDisposable オブジェクトを破棄し、コレクションをクリアします。
        /// </summary>
        public void Clear()
        {
            foreach (var item in _list)
            {
                item.Dispose();
            }
            _list.Clear();
        }

        /// <summary>
        /// 指定した IDisposable オブジェクトがコレクションに含まれているかどうかを確認します。
        /// </summary>
        /// <param name="item">検索するオブジェクト</param>
        /// <returns>含まれていれば true</returns>
        public bool Contains(IDisposable item)
        {
            return _list.Contains(item);
        }

        /// <summary>
        /// コレクションの内容を配列にコピーします。
        /// </summary>
        /// <param name="array">コピー先の配列</param>
        /// <param name="arrayIndex">コピー開始位置</param>
        public void CopyTo(IDisposable[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// コレクション内のすべての IDisposable オブジェクトを破棄し、リストを解放します。
        /// </summary>
        public void Dispose()
        {
            Clear();
            _list = default!;
        }

        /// <summary>
        /// コレクションの列挙子を取得します。
        /// </summary>
        /// <returns>列挙子</returns>
        public IEnumerator<IDisposable> GetEnumerator() => GetEnumerator();

        /// <summary>
        /// 指定した IDisposable オブジェクトをコレクションから削除し、同時に破棄します。
        /// </summary>
        /// <param name="item">削除するオブジェクト</param>
        /// <returns>削除に成功した場合は true</returns>
        public bool Remove(IDisposable item)
        {
            item.Dispose();
            return _list.Remove(item);
        }

        /// <summary>
        /// コレクションの列挙子を取得します（非ジェネリック）。
        /// </summary>
        /// <returns>列挙子</returns>
        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();
    }
}