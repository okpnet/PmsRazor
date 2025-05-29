using Microsoft.AspNetCore.Components;
using QualRazorLib.Controls.Trees;
using QualRazorLib.Core;
using QualRazorLib.Helpers;
using QualRazorLib.Providers.Fields;
using System.Linq.Expressions;

namespace QualRazorLib.Controls.Fields
{
    public partial class QualLabeledField<TModel, TProperty> : QualRazorComponentBase where TModel : class
    {
        protected Expression<Func<TProperty>> _property = default!;

        public const string CASCADE_PARAM = $"{nameof(QualForms<TModel>)}.Parent";

        [CascadingParameter(Name =CASCADE_PARAM)]
        public QualForms<TModel>? QualForms { get; set; } = default!;

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter, EditorRequired]
        public Expression<Func<TProperty>> PropertyValueExpression 
        {
            get => _property;
            set
            {
                _property = value;
                if(QualForms?.Model is not null)
                {
                    Property = ConvertToModelExpression(_property, QualForms.Model);
                }
            }
        }

        protected Expression<Func<TModel, TProperty>>? Property { get; set; }

        internal IInputTypeProvider Provider { get; set; } = default!;

        internal FieldDataType FieldDataTypes { get; set; }


        protected Dictionary<string, object> MergeAttribute => HtmlAttributeHelper.MergeAttributes(
            MeargeAttributeBase,
            new()
            );



        public Expression<Func<TModel, TProperty>> ConvertToModelExpression(Expression<Func<TProperty>> expr,TModel modelInstance)
        {
            if (expr.Body is MemberExpression memberExpr)
            {
                var param = Expression.Parameter(typeof(TModel), "m");

                // 例: model.Id → m.Id に置き換える
                var newBody = Expression.MakeMemberAccess(param, memberExpr.Member);

                return Expression.Lambda<Func<TModel, TProperty>>(newBody, param);
            }

            throw new InvalidOperationException("式が MemberExpression ではありません。");
        }

    }
}
