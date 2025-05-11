using QualRazorCore.Options.Core;

namespace QualRazorCore.Options.Factories
{
    public class CompositeOptionFactory : IOptionFactory
    {
        private readonly object _syncLock = new();

        // 型ごとのオーバーライド登録
        private readonly Dictionary<Type, IOptionFactory> _typeOverrides = new();

        // 優先順位付きFactoryリスト
        private readonly List<IOptionFactory> _factories = new();

        // 最後のフォールバックFactory（null許容）
        public IOptionFactory? FallbackFactory { get; set; }

        public IEnumerable<IOptionFactory> Factories => _factories.AsReadOnly();
        /// <summary>
        /// 指定された型に対応する Option を生成する。
        /// オーバーライド → 優先リスト → fallback の順に探索される。
        /// </summary>
        public IOption? Create(Type targetType)
        {
            lock (_syncLock)
            {
                if (_typeOverrides.TryGetValue(targetType, out var overrideFactory))
                {
                    return overrideFactory.Create(targetType);
                }

                foreach (var factory in _factories)
                {
                    var option = factory.Create(targetType);
                    if (option is not null)
                    {
                        return option;
                    }
                }

                return FallbackFactory?.Create(targetType);
            }
        }

        /// <summary>
        /// 優先順にFactoryを追加（末尾追加）
        /// </summary>
        public void AddFactory(IOptionFactory factory)
        {
            lock (_syncLock)
            {
                if (!_factories.Contains(factory))
                {
                    _factories.Add(factory);
                }
            }
        }

        /// <summary>
        /// 優先順リストからFactoryを削除
        /// </summary>
        public void RemoveFactory(IOptionFactory factory)
        {
            lock (_syncLock)
            {
                _factories.Remove(factory);
            }
        }

        /// <summary>
        /// 指定型に対して、特定のFactoryを上書き登録
        /// </summary>
        public void OverrideFactoryFor(Type type, IOptionFactory factory)
        {
            lock (_syncLock)
            {
                _typeOverrides[type] = factory;
            }
        }

        /// <summary>
        /// 型ごとのオーバーライドを解除
        /// </summary>
        public void RemoveOverrideFor(Type type)
        {
            lock (_syncLock)
            {
                _typeOverrides.Remove(type);
            }
        }

        /// <summary>
        /// 現在のすべての登録Factoryをクリア（fallback除く）
        /// </summary>
        public void ClearAll()
        {
            lock (_syncLock)
            {
                _factories.Clear();
                _typeOverrides.Clear();
            }
        }
    }

}
