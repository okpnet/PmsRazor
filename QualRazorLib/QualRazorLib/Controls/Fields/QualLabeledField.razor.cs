using Microsoft.AspNetCore.Components;
using QualRazorLib.Core;
using QualRazorLib.Helpers;
using QualRazorLib.Providers.Fields;
using System.Linq.Expressions;

namespace QualRazorLib.Controls.Fields
{
    public partial class QualLabeledField<TModel, TProperty> : QualRazorComponentBase where TModel : class
    {
        internal Labels? labels { get; set; }
        internal Fields? fields { get; set; }

        //ラベルパラメータ
        internal Dictionary<string, object>? LabelAttribute { get; set; }

        internal RenderFragment? LabelText { get; set; }

        //フィールドパラメータ
        internal Dictionary<string, object>? FieldAttribute { get; set; }

        internal IInputTypeProvider Provider { get; set; } = default!;

        internal FieldDataType FieldDataTypes { get; set; }

        internal Expression<Func<TModel, TProperty>> PropertyExpression { get; set; } = default!;

        protected Dictionary<string, object> MergeAttribute => HtmlAttributeHelper.MergeAttributes(
            MeargeAttributeBase,
            new()
            {
                ["class"] = "field"
            });

        /// <summary>
        /// 子のラベルタグラッパー
        /// </summary>
        public class Labels : QualRazorComponentBase
        {
            [CascadingParameter(Name = "Parent")]
            public QualLabeledField<TModel, TProperty>? Parent { get; set; }

            [Parameter]
            public RenderFragment? ChildContent { get; set; }

            protected override void OnInitialized()
            {
                base.OnInitialized();
                if (Parent is not null)
                {
                    Parent.labels = this;
                    Parent.LabelAttribute = MeargeAttributeBase;
                    Parent.LabelText = ChildContent;
                }
            }
        }
        /// <summary>
        /// 子のフィールドラッパークラス
        /// </summary>
        public class Fields : QualRazorComponentBase
        {
            [CascadingParameter(Name = "Parent")]
            public QualLabeledField<TModel, TProperty>? Parent { get; set; }
            [Parameter]
            public RenderFragment? ChildContent { get; set; }
            [Parameter, EditorRequired]
            public FieldDataType FieldDataType { get; set; }
            [Parameter, EditorRequired]
            public Expression<Func<TModel, TProperty>> Property { get; set; } = default!;


            protected override void OnInitialized()
            {
                base.OnInitialized();
                if (Parent is not null)
                {
                    Parent.fields = this;
                    Parent.FieldAttribute = MeargeAttributeBase;
                    Parent.FieldDataTypes = FieldDataType;
                    Parent.PropertyExpression = Property;
                }
            }
        }
    }
}
