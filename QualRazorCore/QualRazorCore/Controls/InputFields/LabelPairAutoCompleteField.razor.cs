using BlazorCustomInput.Components;
using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.InputFields.Core;
using QualRazorCore.Controls.InputFields.Options;
using QualRazorCore.Controls.InputFields.Options.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.InputFields
{
    public partial class LabelPairAutoCompleteField<T>: LabelPairField<T>
    {
        [Parameter]
        public RenderFragment? LoadingContent { get; set; }
        
        [Parameter]
        public RenderFragment<IEnumerable<AutocompleteArg<T>>>? AutocompleteFrames { get; set; }

        [Parameter, EditorRequired]
        public new AutocompleteOption<T> Option { get; set; } = default!;
    }
}
