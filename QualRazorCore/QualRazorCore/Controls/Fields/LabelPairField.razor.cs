using Microsoft.AspNetCore.Components;
using QualRazorCore.Core;
using QualRazorCore.Extenssions;
using QualRazorCore.Options.BuiltIn;
using System.Linq.Expressions;

namespace QualRazorCore.Controls.Fields
{
    public partial class LabelPairField<TModel,TProperty>: OptionParameterRazorCore where TModel:class
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; } = default!;

        [Parameter, EditorRequired]
        public Expression<Func<TModel, TProperty>> ExpressionProperty { get; set; } = default!;

        [Parameter]
        public TModel Model { get; set; } = default!;

        protected LabelFieldPairOption<TModel,TProperty> LabelPairOption
        {
            get
            {
                if (BaseOptions is not LabelFieldPairOption<TModel,TProperty> labelPairOption)
                {
                    throw new InvalidCastException($"LabelFieldPairOption cannot be cast '{typeof(LabelFieldPairOption<TModel, TProperty>).Name}'");
                }
                return labelPairOption;
            }
        }

        protected LabelOption LabelOption
        {
            get
            {
                if(OptionRegistryService.Resolve(LabelPairOption.LabelOptionKey) is not LabelOption labelOption)
                {
                    throw new InvalidCastException($"LabelOption cannot be cast '{typeof(LabelOption).Name}'");
                }
                return labelOption;
            }
        }

        protected Dictionary<string, object> MergePairContainerAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                LabelPairOption.PairAdditionalAttributes,
                new([
                    new("disabled",DisabledValue!),
                            new("class","field")
                    ])
                );

        protected Dictionary<string, object> MergeLabelAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                LabelOption.LabelAdditionalAttributes,
                new([
                    new("class","label")
                    ])
                );
    }
}
