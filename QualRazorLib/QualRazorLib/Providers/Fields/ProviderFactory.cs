using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Providers.Fields
{
    public static class ProviderFactory
    {
        public static IInputTypeProvider CreateChekcProvider<T>()
        {
            var type=typeof(T);
            Type underlying = Nullable.GetUnderlyingType(type) ?? type;

            IInputTypeProvider result = underlying == typeof(bool) || underlying == typeof(Boolean) ? 
                new CheckFieldProvider<bool>(true, false) : new CheckFieldProvider<T>();
            return result;
        }
    }
}
