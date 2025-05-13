namespace QualRazorCore.Options.Core
{
    public interface IRegistry<TKey, TItem>
    {
        void Register(TKey key, TItem item);
        bool TryGet(TKey key, out TItem? item);
        bool Contains(TKey key);
        bool Remove(TKey key);
        /// <summary>
        /// 指定したキーに対する Option を取得する。
        /// </summary>
        TItem? Resolve(TKey key);
        IEnumerable<TKey> GetAllKeys();
        IEnumerable<TItem> GetAllItems();
    }

}
