using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Options
{
    public sealed class OptionKey<T> : IOptionKey<T>,IOptionKey, IEquatable<OptionKey<T>>
    {
        public string Name { get; }
        public Type ValueType => typeof(T);

        private OptionKey(string name)
        {
            Name = name;
        }

        public static OptionKey<T> Create(string name)
        {
            return new OptionKey<T>(name);
        }

        public override string ToString() => $"OptionKey<{typeof(T).Name}>: {Name}";

        public override bool Equals(object? obj) => Equals(obj as OptionKey<T>);

        public bool Equals(OptionKey<T>? other)
        {
            return other != null && Name == other.Name;
        }

        public override int GetHashCode() => HashCode.Combine(Name, typeof(T));
    }
}
