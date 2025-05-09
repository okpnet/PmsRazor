using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Options.Registry
{
    public sealed class OptionKey<TPropertyValueType> : IOptionKey<TPropertyValueType>, IOptionKey, IEquatable<IOptionKey>
    {
        public string Name { get; }
        public Type ValueType => typeof(TPropertyValueType);

        private OptionKey(string name)
        {
            Name = name;
        }

        public static OptionKey<TPropertyValueType> Create(string name)
        {
            return new OptionKey<TPropertyValueType>(name);
        }

        public override string ToString() => $"OptionKey<{typeof(TPropertyValueType).Name}>: {Name}";

        public override bool Equals(object? obj) => Equals(obj as OptionKey<TPropertyValueType>);

        public bool Equals(IOptionKey? other)
        {
            return other != null && Name == other.Name;
        }

        public override int GetHashCode() => HashCode.Combine(Name, typeof(TPropertyValueType));
    }
}
