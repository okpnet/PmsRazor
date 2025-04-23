using BlazorCustomInput.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.InputFields.Options
{
    public class StringEmailOption:StringOption
    {
        public override TextEditType TextEditType => TextEditType.Email;

        public StringEmailOption(string? placeHolder) : base(placeHolder, false)
        {
        }
    }
}
