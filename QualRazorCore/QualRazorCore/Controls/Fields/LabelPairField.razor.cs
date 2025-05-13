using Microsoft.AspNetCore.Components;
using QualRazorCore.Core;
using QualRazorCore.Extenssions;
using QualRazorCore.Options.Core;
using QualRazorCore.Options.Helper;
using System.Linq.Expressions;

namespace QualRazorCore.Controls.Fields
{
    public partial class LabelPairField<TModel,TProperty>: OptionParameterRazorCore where TModel:class
    {
        public LabelContent? LabelContentRef { get; set; }

        public FieldContent<TModel, TProperty>? FieldContentRef { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; } = default!;

        [Parameter, EditorRequired]
        public Expression<Func<TModel, TProperty>> ExpressionProperty { get; set; } = default!;

        [Parameter]
        public TModel Model { get; set; } = default!;

        [Parameter]
        public FieldDataType? DataType { get; set; }

        [Parameter]
        public IOptionKey? FieldConfigOptionKey { get; set; }

        /// <summary>
        /// パラメーターのキーが割り当てられないときに、デフォルトの型のキーを使用してViewOptionを取得する
        /// </summary>
        protected override IOptionKey DefaultViewOptionKey => OptionKeyFactory.CreateDefaultKey<LabelPairField<TModel, TProperty>>();

        protected Dictionary<string, object> MergeAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                ViewOptions?.AdditionalAttributes,
                new([
                    new("disabled",DisabledValue!),
                            new("class","field")
                    ])
                );
    }
}
