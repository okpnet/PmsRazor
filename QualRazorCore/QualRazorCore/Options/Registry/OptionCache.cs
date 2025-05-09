using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QualRazorCore.Options.Defaults.Core;

namespace QualRazorCore.Options.Registry
{
    internal class OptionCache
    {
        private readonly Dictionary<(Type modelType, string propertyName), OptionBase> _options = new();

        public OptionBase GetOrAdd(Type modelType, string propertyName, Func<Type, OptionBase> factory)
        {
            var propertyInfo = modelType.GetProperty(propertyName)
                ?? throw new ArgumentException($"プロパティ {propertyName} は見つかりません");

            var key = (modelType, propertyName);
            if (!_options.TryGetValue(key, out var option))
            {
                option = factory(propertyInfo.PropertyType);
                _options[key] = option;
            }

            return option;
        }
    }
}
