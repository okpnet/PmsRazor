using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.InputFields.Core;
using QualRazorCore.Controls.InputFields.Options.Core;
using System.Linq.Expressions;

namespace QualRazorCore.Controls.InputFields
{
    public partial class LabelPairField<T>:FieldCore
    {

        [Parameter, EditorRequired]
        public OptionBase Option { get; set; } = default!;

        [Parameter, EditorRequired]
        public Expression<Func<T>> ValueExpression { get; set; } = default!;
    }
}
