using BlazorCustomInput.Components;
using QualRazorCore.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.InputFields.Options
{
    public class StringEmailOption:StringOption, IOption, INotifyPropertyChanged
    {
        public override TextEditType TextEditType => TextEditType.Email;

        public StringEmailOption(string? placeHolder) : base(placeHolder, false)
        {
        }
    }
}
