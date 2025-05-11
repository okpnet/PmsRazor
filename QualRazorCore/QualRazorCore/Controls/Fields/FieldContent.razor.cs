using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using QualRazorCore.Core;
using QualRazorCore.Options.BuiltIn;
using System.Linq.Expressions;

namespace QualRazorCore.Controls.Fields
{
    public partial class FieldContent<TModel,TProperty>: OptionParameterRazorCore where TModel : class
    {
        [CascadingParameter]
        EditContext? CascadedEditContext { get; set; }

        [Parameter]
        public TModel Model { get; set; } = default!;

        [Parameter]
        public string? Name { get; set; }

        [Parameter,EditorRequired]
        public Expression<Func<TModel, TProperty>>? Property { get; set; }

        protected Expression<Func<TProperty>> PropertyExpression=>()=>GetPropertyValue();

        protected PropertyFieldOption<TModel, TProperty> PropertyFieldOption
        {
            get
            {
                if(BaseOptions is not PropertyFieldOption<TModel, TProperty> propertyFieldOption)
                {
                    throw new InvalidCastException($"PropertyFieldOption cannot be cast '{typeof(PropertyFieldOption<TModel, TProperty>).Name}'");
                }
                return propertyFieldOption;
            }
        }

        protected bool _isInitialize = false;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ArgumentNullException.ThrowIfNull(PropertyFieldOption);
        }

        protected TProperty GetPropertyValue()
        {//EditContextかModelのどちらかが必要
            if (CascadedEditContext?.Model is TModel model)
            {
                return PropertyFieldOption.Getter.Invoke(model);
            }
            
            return Model is null? default!:PropertyFieldOption.Getter.Invoke(Model);
        }
    }
}
