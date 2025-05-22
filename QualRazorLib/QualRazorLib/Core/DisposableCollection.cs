using System.Collections;

namespace QualRazorLib.Core
{
    public class DisposableCollection : ICollection<IDisposable>, IDisposable
    {
        private List<IDisposable> _list = [];
        public int Count => _list.Count;

        public bool IsReadOnly => true;

        public void Add(IDisposable item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            foreach (var item in _list)
            {
                item.Dispose();
            }
            _list.Clear();
        }

        public bool Contains(IDisposable item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(IDisposable[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public void Dispose()
        {
            Clear();
            _list = default!;
        }

        public IEnumerator<IDisposable> GetEnumerator() => GetEnumerator();

        public bool Remove(IDisposable item)
        {
            item.Dispose();
            return _list.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();
    }
}
