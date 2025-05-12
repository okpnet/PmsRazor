using QualRazorCore.Options.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Core
{
    public abstract class RegistryCore<TKey, TItem> : IRegistry<TKey, TItem> where TKey:notnull
    {
        protected readonly Dictionary<TKey, TItem> _store = new();

        public void Register(TKey key, TItem item) => _store[key] = item;
        public bool TryGet(TKey key, out TItem? item) => _store.TryGetValue(key, out item);
        public bool Contains(TKey key) => _store.ContainsKey(key);
        public bool Remove(TKey key) => _store.Remove(key);
        public virtual TItem? Resolve(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (_store.TryGetValue(key, out var obj))
            {
                return obj;
            }

            return default;
        }
        public IEnumerable<TKey> GetAllKeys() => _store.Keys;
        public IEnumerable<TItem> GetAllItems() => _store.Values;
    }

}
