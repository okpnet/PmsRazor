using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Options.Provider
{
    public sealed class OptionRegistry : IOptionRegistry
    {
        private readonly Dictionary<IOptionKey, IOption> _options = new();

        public void Register<T>(OptionKey<T> key, IOption option) where T : class
        {
            if (key is null)
            {
                throw new ArgumentNullException(nameof(key)); 
            }
            if (option == null) 
            {
                throw new ArgumentNullException(nameof(option)); 
            }

            _options[key] = option;
        }

        public IOption? Resolve<T>(OptionKey<T> key) where T : class
        {
            if (key == null) 
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (_options.TryGetValue(key, out var obj) && obj is IOption casted)
            {
                return casted;
            }

            return null;
        }

        public bool Contains<T>(OptionKey<T> key)
        {
            return _options.ContainsKey(key);
        }

        public bool Remove<T>(OptionKey<T> key)
        {
            return _options.Remove(key);
        }

        public IEnumerable<IOptionKey> GetAllKeys() => _options.Keys;
    }
}
