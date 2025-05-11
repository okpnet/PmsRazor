namespace QualRazorCore.Options.Core
{
    /// <summary>
    /// OptionKeyは、オプションのキーを表すクラスです。
    /// </summary>
    /// <typeparam name="TCreateOptionArgType"></typeparam>
    public sealed class OptionKey<TCreateOptionArgType> : IOptionKey<TCreateOptionArgType>, IOptionKey, IEquatable<IOptionKey>
    {
        /// <summary>
        /// オプションの名前を取得します。
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// オプションに渡す型を取得します。
        /// </summary>
        public Type TargetType => typeof(TCreateOptionArgType);
        /// <summary>
        /// OptionKeyのコンストラクタ
        /// </summary>
        /// <param name="name"></param>
        private OptionKey(string name)
        {
            Name = name;
        }
        /// <summary>
        /// OptionKeyを作成します。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static OptionKey<TCreateOptionArgType> Create(string name)
        {
            return new OptionKey<TCreateOptionArgType>(name);
        }
        /// <summary>
        /// OptionKeyの文字列を取得します。
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"OptionKey<{typeof(TCreateOptionArgType).Name}>: {Name}";
        /// <summary>
        /// オプションのキーが等しいかどうかを比較します。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj) => Equals(obj as OptionKey<TCreateOptionArgType>);
        /// <summary>
        /// オプションのキーが等しいかどうかを比較します。
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(IOptionKey? other)
        {
            return other != null && Name == other.Name;
        }
        /// <summary>
        /// オプションのキーのハッシュコードを取得します。
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => HashCode.Combine(Name, typeof(TCreateOptionArgType));
    }
}
