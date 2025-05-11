using QualRazorCore.Core;
using System.ComponentModel;

namespace QualRazorCore.Options.Core
{
    public abstract class OptionBase : NotifyCore, IOption, INotifyPropertyChanged
    {

        protected OptionBase()
        {
        }
    }
}
