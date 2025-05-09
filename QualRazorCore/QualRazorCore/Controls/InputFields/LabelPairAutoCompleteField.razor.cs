using BlazorCustomInput.Components;
using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.InputFields.Core;
using QualRazorCore.Options.Defaults;

namespace QualRazorCore.Controls.InputFields
{
    public partial class LabelPairAutoCompleteField<T>: FieldCore<T>
    {
        [Parameter]
        public RenderFragment LoadingContent { get; set; } = default!;
        
        [Parameter]
        public RenderFragment<IEnumerable<AutocompleteArg<T>>> AutocompleteFrames { get; set; } = default!;

        [Parameter, EditorRequired]
        public new AutocompleteOption<T> Option { get; set; } = default!;
    }
}
