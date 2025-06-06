using Microsoft.AspNetCore.Components;
using QualRazorLib.Core;
using QualRazorLib.Helpers;
using QualRazorLib.Providers.Fields;
using System.Linq.Expressions;

namespace QualRazorLib.Controls.Fields
{
    public partial class QualLabeledSelectGroupField<TProperty> : QualRazorComponentBase
    {
        [Parameter]
        public RenderFragment? LabelContent { get; set; }

        [Parameter]
        public RenderFragment? Options { get; set; }

        [Parameter, EditorRequired]
        public TProperty Value { get; set; } = default!;

        [Parameter]
        public Expression<Func<TProperty>>? PropertyExpression { get; set; }

        [Parameter]
        public EventCallback<TProperty> ValueChanged { get; set; }

        [Parameter]
        public IInputTypeProvider Provider { get; set; } = default!;

        protected SelectFieldProvider<TProperty> SelectProvider => (Provider as SelectFieldProvider<TProperty>) ?? new();

        protected Dictionary<string, object> MergeAttribute => HtmlAttributeHelper.MergeAttributes(
            MergeAttributeBase,
            new()
            {
                [HtmlAtributes.CLASS]=$"{HtmlAtributes.SELECT}"
            }
            );
    }
}
