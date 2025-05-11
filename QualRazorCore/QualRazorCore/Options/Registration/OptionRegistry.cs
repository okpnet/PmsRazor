using QualRazorCore.Extenssions;
using QualRazorCore.Options.Core;
using QualRazorCore.Options.Factories;
using System.Linq.Expressions;

namespace QualRazorCore.Options.Registration
{
    /// <summary>
    /// OptionRegistryは、IOptionを登録し、解決するためのクラスです。
    /// </summary>
    public class OptionRegistry : IOptionRegistry
    {
        /// <summary>
        /// マッピングされたキーとオプションの辞書
        /// </summary>
        private readonly Dictionary<IOptionKey, IOption> _options = new();
        /// <summary>
        /// OptionFactory
        /// </summary>
        private readonly IOptionFactory _optionFactory;
        /// <summary>
        /// OptionRegistryのコンストラクタ
        /// </summary>
        /// <param name="factory"></param>
        public OptionRegistry(IOptionFactory? factory = null)
        {
            _optionFactory = factory ?? new DefaultOptionFactory();
        }
        /// <summary>
        /// 指定されたキーに対して Option を登録する。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="option"></param>
        /// <exception cref="ArgumentNullException"></exception>
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
        /// <summary>
        /// 指定したキーに対する Option を取得する。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual IOption? Resolve(IOptionKey key)
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
        /// <summary>
        /// 指定したキーに対する Option の登録が存在するか確認する。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(IOptionKey key)
        {
            return _options.ContainsKey(key);
        }
        /// <summary>
        /// 指定したキーに対する登録を削除する。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(IOptionKey key)
        {
            return _options.Remove(key);
        }
        /// <summary>
        /// 全ての登録された OptionKey を列挙する（主にUIや開発者向け）。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IOptionKey> GetAllKeys() => _options.Keys;
        /// <summary>
        /// 指定したキーに対して Option を登録する。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="option"></param>
        public void Register(IOptionKey key, IOption option)
        {
            _options[key] = option;
        }
        /// <summary>
        /// 指定したキーに対する Option を取得する。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="option"></param>
        /// <returns></returns>
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
        /// <summary>
        /// プロパティの式を指定して、Option を登録します。
        /// </summary>
        /// <typeparam name="TOwner"></typeparam>
        /// <typeparam name="TPropertyType"></typeparam>
        /// <param name="propertyExpression"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IOptionKey RegisterFromExpression<TOwner, TPropertyType>(Expression<Func<TOwner, TPropertyType>> propertyExpression)
        {
            var name = ExpressionHelper.GetPropertyPath(propertyExpression);
            var key = OptionKey<TPropertyType>.Create(name);
            var option = _optionFactory is IExtendOptionFactory extendOption ? extendOption.Create(propertyExpression) : _optionFactory.Create(typeof(TPropertyType));
            ArgumentNullException.ThrowIfNull(option);
            Register(key, option);
            return key;
        }
        /// <summary>
        /// プロパティの式を指定して、Option を登録します。
        /// </summary>
        /// <typeparam name="TOwner"></typeparam>
        /// <typeparam name="TPropertyType"></typeparam>
        /// <param name="propertyExpression"></param>
        /// <param name="custumOption"></param>
        /// <returns></returns>
        public IOptionKey RegisterFromExpression<TOwner, TPropertyType>(Expression<Func<TOwner, TPropertyType>> propertyExpression,IOption custumOption)
        {
            var name = ExpressionHelper.GetPropertyPath(propertyExpression);
            var key = OptionKey<TPropertyType>.Create(name);
            Register(key, custumOption);
            return key;
        }
    }
}
