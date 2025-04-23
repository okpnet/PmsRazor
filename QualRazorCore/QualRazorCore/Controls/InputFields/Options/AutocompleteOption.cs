using BlazorCustomInput.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.InputFields.Options
{
    public class AutocompleteOption<T> : StringOption
    {
        public Func<T, string> GetValue { get; set; } = default!;
        public Func<T?, Task<T[]>> FindItemTask { get; set; }

        public RenderFragment<IEnumerable<AutocompleteArg<T>>> AutocompleteFrames { get; set; }

        public RenderFragment LoadingTemplae { get; set; }

        public EventCallback LoadCompleteEvent { get; set; }
    }
}
