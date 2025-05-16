using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.Fields.Options;
using QualRazorCore.Options.Configurations.Core;
using QualRazorCore.Options.Core;
using System.ComponentModel;

namespace QualRazorCore.Options.Configurations.Builtin
{
    public class AutocompleteOption<T> : TextConfigOption, IConfigOption,IOption, INotifyPropertyChanged
    {
        public Func<T, string> GetValue { get; set; } = default!;

        public Func<T?, Task<T[]>> FindItemTask { get; set; } = default!;

        public EventCallback LoadCompleteEvent { get; set; }

    }
}