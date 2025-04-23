using BlazorCustomInput.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.InputFields.Options
{
    public class StringPasswordOption:StringOption
    {
        public override TextEditType TextEditType => TextEditType.Password;
        public StringPasswordOption(string? placeHolder) : base(placeHolder, false)
        {
        }

    }
}
