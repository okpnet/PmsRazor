using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace QualRazorCore.Options.Defaults
{
    public class AutocompleteOption<T> : StringOption, IOption, INotifyPropertyChanged
    {
        public Func<T, string> GetValue { get; set; } = default!;

        public Func<T?, Task<T[]>> FindItemTask { get; set; } = default!;

        public EventCallback LoadCompleteEvent { get; set; }

        public AutocompleteOption(string? placeHolder, Func<T, string> getValue, Func<T?, Task<T[]>> findItemTask, EventCallback loadCompleteEvent) : base(placeHolder, false)
        {
        }
    }
}