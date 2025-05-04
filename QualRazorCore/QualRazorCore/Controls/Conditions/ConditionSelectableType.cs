using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Conditions
{
    public enum ConditionSelectableType : byte
    {
        BOOL = 0b0,
        NUM = 0b1,
        STR = 0b10,
    }
}
