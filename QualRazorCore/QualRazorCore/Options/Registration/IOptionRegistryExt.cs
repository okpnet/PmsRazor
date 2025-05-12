using QualRazorCore.Core;
using QualRazorCore.Options.Core;
using QualRazorCore.Options.Factories;

namespace QualRazorCore.Options.Registration
{
    public interface IOptionRegistryExt : IOptionRegistry
    {
        /// <summary>
        /// 指定された型に対応する Option を Factory 経由で動的に生成して登録または返す。
        /// </summary>
        IOption? ResolveOrCreate(IOptionKey key, Type optionType);

        /// <summary>
        /// Option の生成に使われる IOptionFactory を動的に登録する（CompositeFactoryに渡す）。
        /// </summary>
        void RegisterFactory(IOptionFactory factory);

        /// <summary>
        /// 登録済みのファクトリ群を列挙する（主に診断用）。
        /// </summary>
        IEnumerable<IOptionFactory> GetFactories();
    }

}
