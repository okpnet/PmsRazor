using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using QualRazorCore.Controls.InputFields.Options.Core;
using QualRazorCore.Core;
using System.Linq.Expressions;

namespace QualRazorCore.Controls.InputFields.Core
{
    public class FieldCore:RazorCore
    {
        [CascadingParameter]
        protected EditContext? CascadedEditContext { get; set; }

        [Parameter]
        public RenderFragment PreContent { get; set; } = default!;

        [Parameter]
        public RenderFragment LabelContent { get; set; } = default!;

        [Parameter, EditorRequired]
        public OptionBase Option { get; set; } = default!;
    }

    public class FieldCore<T> : FieldCore
    {
        [Parameter, EditorRequired]
        public Expression<Func<T>> ValueExpression { get; set; } = default!;
    }
}
