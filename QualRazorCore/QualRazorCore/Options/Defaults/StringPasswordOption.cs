using BlazorCustomInput.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Options.Defaults
{
    public class StringPasswordOption : StringOption, IOption, INotifyPropertyChanged
    {
        public override TextEditType TextEditType => TextEditType.Password;
        public StringPasswordOption(string? placeHolder) : base(placeHolder, false)
        {
        }
    }
}
