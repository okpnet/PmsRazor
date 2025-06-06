using Microsoft.AspNetCore.Components;
using QualRazorLib.Core;
using QualRazorLib.Helpers;
using QualRazorLib.Providers.Fields;
using System.Linq.Expressions;

namespace QualRazorLib.Controls.Fields
{
    public partial class QualLabeledRadioGroupField<TProperty> : QualRazorComponentBase
    {
        [Parameter]
        public RenderFragment? LabelContent { get; set; }

        [Parameter]
        public RenderFragment? Radios {  get; set; }

        [Parameter, EditorRequired]
        public TProperty Value { get; set; } = default!;

        [Parameter]
        public EventCallback<TProperty> ValueChanged { get; set; }


        protected TProperty PropertyValue
        {
            get => Value;
            set
            {
                if (Equals(Value, value))
                {
                    return;
                }
                Value = value;
                ValueChanged.InvokeAsync(Value);
            }
        }


        protected Dictionary<string, object> MergeAttribute => HtmlAttributeHelper.MergeAttributes(
            MergeAttributeBase,
            new()
            );

    }
}
