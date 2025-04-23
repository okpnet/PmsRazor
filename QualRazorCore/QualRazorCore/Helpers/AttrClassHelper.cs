using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Helpers
{
    public static class AttrClassHelper
    {
        public static bool HasClassValue(this Dictionary<string, object>? attrs, string key)
        {
            if(attrs is null || !attrs.TryGetValue("class", out var classes) || classes is not string classString || !classString.Contains(key))
            {
                return false;
            }
            return true;
        }
    }
}
