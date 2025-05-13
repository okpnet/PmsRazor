using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using QualRazorCore.Options.Configurations.Core;
using QualRazorCore.Options.Core;
using System.ComponentModel;

namespace QualRazorCore.Options.Configurations.Builtin
{
    public class ButtonConfigOption:ConfigOption,IConfigOption, IOption, INotifyPropertyChanged
    {
        public EventCallback<MouseEventArgs> ButtonUp { get; set; } = EventCallback<MouseEventArgs>.Empty;

        public EventCallback ButtonClick { get; set; } = EventCallback.Empty;

        public EventCallback<MouseEventArgs> ButtonDown { get; set; } = EventCallback<MouseEventArgs>.Empty;
    }
}
