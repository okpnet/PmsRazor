using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore
{
    [Flags]
    public enum InformationType
    {
        None=0,
        Success=1 << 0,
        Warning = 1 << 1,
        Danger = 1 << 2,
        Download= 1 << 3,
    }

}
