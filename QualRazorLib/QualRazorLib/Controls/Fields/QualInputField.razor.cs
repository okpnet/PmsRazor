using BlazorCustomInput.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using QualRazorLib.Core;
using QualRazorLib.Helpers;
using QualRazorLib.Providers.Fields;
using System.Linq.Expressions;

namespace QualRazorLib.Controls.Fields
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

        [Parameter,EditorRequired]
        public TProperty Value { get; set; } = default!;

        [Parameter]
        public EventCallback<TProperty> ValueChanged { get; set; }

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
            MeargeAttributeBase,
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
            var attrDictionary=new Dictionary<string, object>();
            switch (FieldDataTypes)
            {
                case FieldDataType.Text:
                    if (Provider is TextFieldProvider textProvider)
                    {
                        attrDictionary[HtmlAtributes.TYPE] = textProvider.EditType.GetTypeString();
                    }
                    attrDictionary[HtmlAtributes.CLASS] = "input";
                    break;
                case FieldDataType.Number:
                    attrDictionary[HtmlAtributes.TYPE] = "number";
                    attrDictionary[HtmlAtributes.CLASS] = "input";
                    break;
                case FieldDataType.Date:
                    attrDictionary[HtmlAtributes.TYPE] = "date";
                    attrDictionary[HtmlAtributes.CLASS] = "input";
                    break;
                case FieldDataType.DateTime:
                    attrDictionary[HtmlAtributes.TYPE] = "datetime-local";
                    attrDictionary[HtmlAtributes.CLASS] = "input";
                    break;
                case FieldDataType.TiemSpan:
                    attrDictionary[HtmlAtributes.TYPE] = "time";
                    attrDictionary[HtmlAtributes.CLASS] = "input";
                    break;
                case FieldDataType.Check:
                    attrDictionary[HtmlAtributes.TYPE] = "checkbox";
                    attrDictionary[HtmlAtributes.CLASS] = "input";
                    break;
                case FieldDataType.Select:
                    attrDictionary[HtmlAtributes.CLASS] = "select";
                    break;

            }
            return attrDictionary;
        }
    }
}
