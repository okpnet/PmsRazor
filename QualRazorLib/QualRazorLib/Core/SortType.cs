using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Core
{
    [Flags]
    public enum SortType
    {
        None = 0,
        ASC = 1 << 0,
        DESC = 1 << 1
    }
}
