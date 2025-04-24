using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Dialogs.Core
{
    public enum DialogResult
    {
        None = 0,
        Close = 1 << 0,
        Primary = 1 << 1,
        Secondary = 1 << 2,
        Tertiary = 1 << 3
    }
}
