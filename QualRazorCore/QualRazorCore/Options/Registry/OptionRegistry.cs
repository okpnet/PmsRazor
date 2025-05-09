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
        public void Register<T>(IOptionKey key, IOption option) where T : class
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

        public void Register(IOptionKey key, IOption option)
        {
            _options[key] = option;
        }

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

        public IOptionKey RegisterFromExpression<TOwner, TPropertyValueType>(Expression<Func<TOwner, TPropertyValueType>> propertyExpression)
        {
            var name = GetFullPropertyPath(propertyExpression.Body);
            var key = OptionKey<TPropertyValueType>.Create(name);
            var option = _optionFactory.Create(typeof(TPropertyValueType));
            if(option is null)
            {
                throw new ArgumentNullException($"{typeof(TPropertyValueType).Name} of type {nameof(IOptionFactory)} is result null.");
            }
            Register(key, option);
            return key;
        }

        public IOptionKey RegisterFromExpression<TOwner, TOption>(Expression<Func<TOwner, TPropertyValueType>> propertyExpression) where TOption :IOption
        {
            var name = GetFullPropertyPath(propertyExpression.Body);
            var key = OptionKey<TPropertyValueType>.Create(name);
            var option = _optionFactory.Create(typeof(TProperty));
            Register(key, option);
            return key;
        }

        private static string GetFullPropertyPath(Expression expression)
        {
            var stack = new Stack<string>();

            while (expression is MemberExpression memberExpr)
            {
                stack.Push(memberExpr.Member.Name);
                expression = memberExpr.Expression!;
            }

            return string.Join(".", stack);
        }
    }
}
