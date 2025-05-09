using BlazorCustomInput.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Options.Defaults
{
    public class StringEmailOption : StringOption, IOption, INotifyPropertyChanged
    {
        public override TextEditType TextEditType => TextEditType.Email;

        public StringEmailOption(string? placeHolder) : base(placeHolder, false)
        {
        }
    }
}
