using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.Fields.Options;
using QualRazorCore.Core;
using QualRazorCore.Extenssions;
using System.Linq.Expressions;

namespace QualRazorCore.Controls.Fields
{
    public partial class LabeledField<TModel,TProperty>:RazorCore where TModel : class
    {
        internal Labels? labels { get; set; }
        internal Fields? fields { get; set; }

        //ラベルパラメータ
        internal Dictionary<string, object>? LabelAttribute { get; set; }

        internal RenderFragment? LabelText { get; set; }

        //フィールドパラメータ
        internal Dictionary<string, object>? FieldAttribute { get; set; }

        internal FieldOpionBase FieldOpion { get; set; } = default!;

        internal FieldDataType FieldDataTypes { get; set; }

        internal Expression<Func<TModel, TProperty>> PropertyExpression { get; set; } = default!;

        protected Dictionary<string, object> MergeAttribute => HtmlAttributeHelper.MergeAttributes(
            MergeAttribute,
            new()
            {
                ["class"] = "field"
            });

        /// <summary>
        /// 子のラベルタグラッパー
        /// </summary>
        public class Labels : RazorCore
        {
            [CascadingParameter(Name ="Parent")]
            public LabeledField<TModel, TProperty>? Parent { get; set; }

            [Parameter]
            public RenderFragment? ChildContent { get; set; }
            
            protected override void OnInitialized()
            {
                base.OnInitialized();
                if(Parent is not null)
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
        public class Fields : RazorCore
        {
            [CascadingParameter(Name = "Parent")]
            public LabeledField<TModel, TProperty>? Parent { get; set; }
            [Parameter]
            public RenderFragment? ChildContent { get; set; }
            [Parameter,EditorRequired]
            public FieldDataType FieldDataType { get; set; }
            [Parameter,EditorRequired]
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
