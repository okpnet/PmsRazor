using QualRazorCore.Extenssions;
using QualRazorCore.Options.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Options.Registry
{
    public sealed class OptionRegistry : IOptionRegistry
    {
        private readonly Dictionary<IOptionKey, IOption> _options = new();
        private readonly IOptionFactory _optionFactory;

        public OptionRegistry(IOptionFactory? factory = null)
        {
            _optionFactory = factory ?? new DefaultOptionFactory();
        }

        public void Register(IOptionKey key, IOption option)
        {
            ArgumentNullException.ThrowIfNull(key);
            ArgumentNullException.ThrowIfNull(option);

            _options[key] = option;
        }

        public IOption? Resolve(IOptionKey key)
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

        public bool Contains(IOptionKey key)
        {
            return _options.ContainsKey(key);
        }

        public bool Remove(IOptionKey key)
        {
            return _options.Remove(key);
        }

        public IEnumerable<IOptionKey> GetAllKeys() => _options.Keys;

        public bool TryGet(IOptionKey key, out IOption? option)
        {
            if (_options.TryGetValue(key, out var value) && value is IOption typed)
            {
                option = typed;
                return true;
            }

            option = null;
            return false;
        }

        public IOptionKey RegisterFromExpression<TOwner, TOptionType>(Expression<Func<TOwner, TOptionType>> propertyExpression)
        {
            var name = ExpressionHelper.GetPropertyPath(propertyExpression);
            var key = OptionKey<TOptionType>.Create(name);
            var option = _optionFactory.Create(typeof(TOptionType)) 
                ?? throw new ArgumentNullException($"{typeof(TOptionType).Name} of type {nameof(IOptionFactory)} is result null.");
            Register(key, option);
            return key;
        }
    }
}
