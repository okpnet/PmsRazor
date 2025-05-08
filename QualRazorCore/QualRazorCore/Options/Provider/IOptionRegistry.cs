using QualRazorCore.Controls.Tables.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Options.Provider
{
    public interface IOptionRegistry
    {
        /// <summary>
        /// 指定したキーに対して Option を登録する。
        /// </summary>
        void Register<T>(OptionKey<T> key, IOption option) where T : class;

        /// <summary>
        /// 指定したキーに対する Option を取得する。
        /// </summary>
        IOption? Resolve<T>(OptionKey<T> key) where T : class;

        /// <summary>
        /// 指定したキーに対する Option の登録が存在するか確認する。
        /// </summary>
        bool Contains<T>(OptionKey<T> key);

        /// <summary>
        /// 指定したキーに対する登録を削除する。
        /// </summary>
        bool Remove<T>(OptionKey<T> key);

        /// <summary>
        /// 全ての登録された OptionKey を列挙する（主にUIや開発者向け）。
        /// </summary>
        IEnumerable<IOptionKey> GetAllKeys();
    }
}
