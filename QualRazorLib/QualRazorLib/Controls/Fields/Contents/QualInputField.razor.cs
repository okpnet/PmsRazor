using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using QualRazorLib.Core;
using QualRazorLib.Helpers;
using QualRazorLib.Providers.Fields;
using System.Linq.Expressions;

namespace QualRazorLib.Controls.Fields.Contents
{
    public partial class QualInputField<TProperty> : QualRazorComponentBase
    {
        [CascadingParameter]
        EditContext? CascadedEditContext { get; set; }

        [Parameter]
        public FieldDataType? FieldDataTypes { get; set; }

        [Parameter]
        public IInputTypeProvider Provider { get; set; } = default!;

        [Parameter, EditorRequired]
        public Expression<Func<TProperty>> PropertyExpression { get; set; } = default!;

        [Parameter, EditorRequired]
        public TProperty Value { get; set; } = default!;

        [Parameter]
        public EventCallback<TProperty> ValueChanged { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        protected TProperty PropertyValue
        {
            get => Value;
            set
            {
                if (Equals(Value, value))
                {
                    return;
                }
                Value = value;
                ValueChanged.InvokeAsync(Value);
            }
        }

        protected Dictionary<string, object> MergeAttribute => HtmlAttributeHelper.MergeAttributes(
            MergeAttributeBase,
            ChangeTypeToAttributeString()
            );

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (FieldDataTypes is null || FieldDataTypes == FieldDataType.None)
            {
                FieldDataTypes = FieldDataTypeHelper.GetFieldType(typeof(TProperty));
            }
        }

        protected Dictionary<string, object> ChangeTypeToAttributeString()
        {
            var attrDictionary = new Dictionary<string, object>();
            switch (FieldDataTypes)
            {
                case FieldDataType.Check:
                    //checkboxの場合は、inputのtypeをcheckboxにする
                    break;
                default:
                    attrDictionary[HtmlAtributes.CLASS] = HtmlAtributes.INPUT;
                    break;

            }
            return attrDictionary;
        }
    }
}
