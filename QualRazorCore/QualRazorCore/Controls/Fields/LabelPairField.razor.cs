using QualRazorCore.Core;
using QualRazorCore.Extenssions;
using QualRazorCore.Options.BuiltIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Fields
{
    public partial class LabelPairField<TModel,TProperty>: OptionParameterRazorCore where TModel:class
    {

        protected LabelPairOption<TProperty> LabelOption
        {
            get
            {
                if (BaseOptions is not LabelPairOption<TProperty> labelPairOption)
                {
                    throw new InvalidCastException($"LabelPairOption cannot be cast '{typeof(LabelPairOption<TProperty>).Name}'");
                }
                return labelPairOption;
            }
        }
        protected Dictionary<string, object> MergeFieldAttributes =>
    HtmlAttributeHelper.PurgeAttributes(
        LabelOption.FieldLabelAdditionalAttributes,
        new([
            new("disabled",DisabledValue!),
                    new("class","field")
            ])
        );

        protected Dictionary<string, object> MergeFieldLabelAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                LabelOption.,
                new([
                    new("class","label")
                    ])
                );
    }
}
