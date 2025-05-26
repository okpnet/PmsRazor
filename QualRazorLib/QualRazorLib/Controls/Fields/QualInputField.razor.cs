using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using QualRazorLib.Core;
using QualRazorLib.Helpers;
using QualRazorLib.Providers;
using System.Linq.Expressions;

namespace QualRazorLib.Controls.Fields
{
    public partial class QualInputField<TModel, TProperty> : QualRazorComponentBase where TModel : class
    {
        [CascadingParameter]
        EditContext? CascadedEditContext { get; set; }

        [Parameter]
        public TModel Model { get; set; } = default!;

        [Parameter, EditorRequired]
        public Expression<Func<TModel, TProperty>>? Property { get; set; }

        [Parameter]
        public FieldDataType? FieldDataTypes { get; set; }

        [Parameter, EditorRequired]
        public IInputTypeProvider Provider { get; set; } = default!;

        protected Expression<Func<TProperty>> PropertyExpression => () => GetPropertyValue();

        protected TProperty Value
        {
            get => _getter.Invoke(Model);
            set => _setter?.Invoke(Model, value);
        }

        protected Action<TModel, TProperty>? _setter;

        protected Func<TModel, TProperty> _getter = default!;

        public override Task SetParametersAsync(ParameterView parameters)
        {
            if (parameters.TryGetValue<Expression<Func<TModel, TProperty>>>(nameof(Property), out var expression))
            {
                try
                {
                    _getter = ExpressionHelper.BuildGetter(expression);
                }
                catch (Exception ex)
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

            return Model is null ? default! : _getter.Invoke(Model);
        }

        protected void SetPropertyValue(TProperty value)
        {
            var model = CascadedEditContext?.Model is TModel ? (TModel)CascadedEditContext.Model : Model;
            if (_setter is null || model is null)
            {
                return;
            }
            _setter.Invoke(model, value);
        }
    }
}
