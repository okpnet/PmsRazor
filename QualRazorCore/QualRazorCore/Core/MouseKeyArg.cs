using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Core
{
    public class MouseKeyArg
    {
        public bool IsShiftKey { get; }

        public bool IsAltKey { get; }

        public MouseKeyArg(bool isShiftKey, bool isAltKey)
        {
            IsShiftKey = isShiftKey;
            IsAltKey = isAltKey;
        }
    }
}
