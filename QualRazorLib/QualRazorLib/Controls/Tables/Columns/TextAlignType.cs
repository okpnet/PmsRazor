using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Controls.Tables.Columns
{
    [Flags]
    public enum TextAlignType
    {
        Auto=0,
        Left=1<<1,
        Center=1<<2,
        Right=1<<3,
    }
}
