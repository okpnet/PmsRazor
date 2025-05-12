using QualRazorCore.Core;
using QualRazorCore.Options.Core;
using QualRazorCore.Options.Factories;

namespace QualRazorCore.Options.Registration
{

    /// <summary>
    /// FactoryBackedOptionRegistryは、IOptionを登録し、解決するためのクラスです。
    /// </summary>
    public class FactoryBackedOptionRegistry : OptionRegistry, IOptionRegistryExt,IOptionRegistry
    {
        /// <summary>
        /// 複合的なOptionFactory
        /// </summary>
        private readonly CompositeOptionFactory _factory;
        /// <summary>
        /// FactoryBackedOptionRegistryのコンストラクタ
        /// </summary>
        /// <param name="factory"></param>
        public FactoryBackedOptionRegistry(CompositeOptionFactory factory)
        {
            _factory = factory;
        }
        /// <summary>
        /// 指定されたキーに対する Option を取得する。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override IOption? Resolve(IOptionKey key)
        {
            // キャッシュから取得
            var cached = base.Resolve(key);
            if (cached is not null)
                return cached;

            // Factory から生成できるなら生成してキャッシュ登録
            var generated = _factory.Create(key.TargetType);
            if (generated != null)
            {
                base.Register(key, generated);
            }

            return generated;
        }
        /// <summary>
        /// 指定された型に対応する Option を Factory 経由で動的に生成して登録または返す。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="optionType"></param>
        /// <returns></returns>
        public IOption? ResolveOrCreate(IOptionKey key, Type optionType)
        {
            return Resolve(key); // 今は TargetType を使ってる前提
        }

        public void RegisterFactory(IOptionFactory factory)
        {
            _factory.AddFactory(factory);
        }
        /// <summary>
        /// 登録済みのファクトリ群を列挙する（主に診断用）。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IOptionFactory> GetFactories()
        {
            return _factory.Factories;
        }
    }


}
