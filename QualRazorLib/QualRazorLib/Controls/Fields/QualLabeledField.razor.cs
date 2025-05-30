using Microsoft.AspNetCore.Components;
using QualRazorLib.Core;
using QualRazorLib.Helpers;
using QualRazorLib.Providers.Fields;
using System.Linq.Expressions;

namespace QualRazorLib.Controls.Fields
{
    public partial class QualLabeledField<TProperty> : QualRazorComponentBase
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter, EditorRequired]
        public TProperty Value { get; set; } = default!;

        [Parameter]
        public Expression<Func<TProperty>>? PropertyExpression { get; set; }

        [Parameter]
        public EventCallback<TProperty> ValueChanged { get; set; }

        [Parameter]
        public FieldDataType? FieldDataTypes { get; set; }

        [Parameter]
        public IInputTypeProvider Provider { get; set; } = default!;

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
            MeargeAttributeBase,
            new()
            );

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }
}
