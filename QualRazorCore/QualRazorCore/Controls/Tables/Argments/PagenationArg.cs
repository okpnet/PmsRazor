using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Tables.Argments
{
    public class PagenationArg
    {
        public bool Active { get; }

        public Func<string> Label { get; }

        public PagenationArg(bool active, Func<string> label)
        {
            Active = active;
            Label = label;
        }
    }
}
