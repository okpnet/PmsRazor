namespace QualRazorCore.Options.Core
{
    /// <summary>
    /// OptionKeyは、オプションのキーを表すクラスです。
    /// </summary>
    /// <typeparam name="TCreateOptionArgType"></typeparam>
    public sealed class OptionKey : IOptionKey, IEquatable<IOptionKey>
    {
        /// <summary>
        /// オプションの名前を取得します。
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// オプションに渡す型を取得します。
        /// </summary>
        public Type TargetType { get; }
        /// <summary>
        /// OptionKeyのコンストラクタ
        /// </summary>
        /// <param name="name"></param>
        public OptionKey(string name, Type type)
        {
            Name = name;
            TargetType = type;
        }
        /// <summary>
        /// OptionKeyの文字列を取得します。
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"OptionKey<{TargetType.Name}>: {Name}";
        /// <summary>
        /// オプションのキーが等しいかどうかを比較します。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj) => Equals(obj as OptionKey);
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
        public override int GetHashCode() => HashCode.Combine(Name, TargetType);
    }
}
