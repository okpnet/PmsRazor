using Microsoft.AspNetCore.Components;
using QualRazorCore.Core;
using QualRazorCore.Extenssions;
using QualRazorCore.Options.Core;
using QualRazorCore.Options.Helper;

namespace QualRazorCore.Controls.Fields
{
    public partial class LabelContent: OptionParameterRazorCore
    {


        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        protected override IOptionKey DefaultViewOptionKey =>  OptionKeyFactory.CreateDefaultKey<LabelContent>();

        protected Dictionary<string, object> MergeAttribute => HtmlAttributeHelper.MergeAttributes(
            ViewOptions?.AdditionalAttributes ?? new(),
            new());

    }
}
