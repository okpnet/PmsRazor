using Microsoft.AspNetCore.Components;
using QualRazorLib.Core;

namespace QualRazorLib.Controls.Fields.Contents
{
    public partial class QualSelectOption<TProperty> : QualRazorComponentBase
    {
        [Parameter]
        public TProperty Value { get; set; }

        [Parameter]
        public EventCallback<TProperty> ValueChanged { get; set; }

        [Parameter]
        public bool IsPlaceholder { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
