using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using QualRazorCore.Core;
using QualRazorCore.Extenssions;
using QualRazorCore.Options.Configurations.Core;
using QualRazorCore.Options.Core;
using QualRazorCore.Options.Helper;
using System.Linq.Expressions;

namespace QualRazorCore.Controls.Fields
{
    public partial class FieldContent<TModel,TProperty>: OptionParameterRazorCore where TModel : class
    {
        [CascadingParameter]
        EditContext? CascadedEditContext { get; set; }

        [Parameter]
        public TModel Model { get; set; } = default!;

        [Parameter,EditorRequired]
        public Expression<Func<TModel, TProperty>>? Property { get; set; }

        [Parameter]
        public FieldDataType? FieldDataTypes { get; set; }

        [Parameter]
        public IOptionKey? FieldConfigOptionKey { get; set; }

        protected Expression<Func<TProperty>> PropertyExpression=>()=>GetPropertyValue();

        protected IConfigOption? ConfigOption => FieldConfigOptionKey is null ? null : ConfigOptionRegistryService.Resolve(FieldConfigOptionKey);

        /// <summary>
        /// パラメーターのキーが割り当てられないときに、デフォルトの型のキーを使用してViewOptionを取得する
        /// </summary>
        protected override IOptionKey DefaultViewOptionKey => OptionKeyFactory.CreateDefaultKey<FieldContent<TModel, TProperty>>();

        protected TProperty Value 
        { 
            get=>_getter.Invoke(Model);
            set=>_setter?.Invoke(Model, value);
        }

        protected Action<TModel, TProperty>? _setter;

        protected Func<TModel, TProperty> _getter=default!;

        public override Task SetParametersAsync(ParameterView parameters)
        {
            if(parameters.TryGetValue<Expression<Func<TModel, TProperty>>>(nameof(Property),out var expression))
            {
                try
                {
                    _getter = ExpressionHelper.BuildGetter(expression);
                }catch(Exception ex)
                {
                    throw;
                }
                try
                {
                    _setter = ExpressionHelper.BuildSetter(expression);
                }
                finally
                {
                    _setter = null;
                }

                if (!parameters.TryGetValue<FieldDataType>(nameof(FieldDataTypes), out var types))
                {
                    FieldDataTypes = FieldDataTypeHelper.GetFieldType(typeof(TProperty));
                }
            }

            return base.SetParametersAsync(parameters);
        }

        protected TProperty GetPropertyValue()
        {//EditContextかModelのどちらかが必要
            if (CascadedEditContext?.Model is TModel model)
            {
                return _getter.Invoke(model);
            }
            
            return Model is null? default!: _getter.Invoke(Model);
        }

        protected void SetPropertyValue(TProperty value)
        {
            var model = CascadedEditContext?.Model is TModel ? (TModel)CascadedEditContext.Model : Model;
            if(_setter is null || model is null)
            {
                return;
            }
            _setter.Invoke(model,value);
        }
    }
}
