using QualRazorCore.Core;
using QualRazorCore.Options.Configurations.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Options.Configurations.Builtin
{
    public abstract class ConfigOption:NotifyCore,IConfigOption,INotifyPropertyChanged
    {
    }
}
