using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.InputFields.Core;
using QualRazorCore.Controls.InputFields.Options.Core;
using QualRazorCore.Extenssions;
using System.Data.Common;
using System.Linq.Expressions;

namespace QualRazorCore.Controls.InputFields
{
    public partial class LabelPairField<T>:FieldCore<T>
    {
        protected Dictionary<string, object> MergeFieldAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                Option.FieldAdditionalAttributes,
                new([
                    new("disabled",DisabledValue!),
                    new("class","field")
                    ])
                );

        protected Dictionary<string, object> MergeFieldLabelAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                Option.FieldAdditionalAttributes,
                new([
                    new("class","label")
                    ])
                );
    }
}
