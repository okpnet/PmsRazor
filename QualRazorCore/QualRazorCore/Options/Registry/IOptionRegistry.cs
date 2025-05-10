using System.Linq.Expressions;

namespace QualRazorCore.Options.Registry
{
    public interface IOptionRegistry
    {
        /// <summary>
        /// 指定したキーに対して Option を登録する。
        /// </summary>
        void Register(IOptionKey key, IOption option);

        /// <summary>
        /// 指定したキーに対する Option を取得する。
        /// </summary>
        IOption? Resolve(IOptionKey key);

        /// <summary>
        /// 指定したキーに対する Option の登録が存在するか確認する。
        /// </summary>
        bool Contains(IOptionKey key);

        /// <summary>
        /// 指定したキーに対する登録を削除する。
        /// </summary>
        bool Remove(IOptionKey key);

        /// <summary>
        /// 全ての登録された OptionKey を列挙する（主にUIや開発者向け）。
        /// </summary>
        IEnumerable<IOptionKey> GetAllKeys();

        bool TryGet(IOptionKey key, out IOption? option);

        IOptionKey RegisterFromExpression<TOwner, TOptionType>(Expression<Func<TOwner, TOptionType>> propertyExpression);

    }
}
