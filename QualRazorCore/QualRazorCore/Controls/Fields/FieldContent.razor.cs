using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using QualRazorCore.Core;
using QualRazorCore.Options.Defaults.Core;
using QualRazorCore.Options.Registry;
using System.Linq.Expressions;

namespace QualRazorCore.Controls.Fields
{
    public partial class FieldContent<TModel,TProperty>:OptionParameterRazorCore where TModel:class
    {
        /// <summary>
        /// 
        /// </summary>
        [CascadingParameter]
        EditContext? CascadedEditContext { get; set; }

        [Parameter]
        public string Name { get; set; } = string.Empty;

        [Parameter, EditorRequired]
        public Expression<Func<TModel, TProperty>> PathExpression { get; set; } = default!;

        [Parameter]
        public TProperty Value { get; set; } = default!;

        protected PropertyFieldOption<TModel, TProperty> FieldOption
        {
            get
            {
                var result = BaseOptions as PropertyFieldOption<TModel, TProperty>;
                ArgumentNullException.ThrowIfNull(result);
                return result;
            }
        }

        protected TModel ConvertedModel
        {
            get
            {
                var result = CascadedEditContext?.Model as  TModel;
                ArgumentNullException.ThrowIfNull(result);
                return result;
            }
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            FieldOption.Init(PathExpression);
        }
    }
}
