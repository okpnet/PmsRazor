using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Controls.Tables
{
    [Flags]
    public enum RowStatus : byte
    {
        None = 0,
        Edit = 1 << 0,
        Seleted = 1 << 1,
        Drag = 1 << 2,
    }
}
