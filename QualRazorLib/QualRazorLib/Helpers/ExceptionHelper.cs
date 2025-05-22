using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Helpers
{
    public static class ExceptionHelper
    {
        public static void ThrowIfCastTypeUnmatch<TCast>(object castObject,string? message = null)
        {
            if(castObject is TCast)
            {
                return;
            }
            var msg = message ?? $"{castObject.GetType().Name} un match cast type '{typeof(TCast).Name}'";
            throw new InvalidCastException(msg);
        }
    }
}
