using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using QualAnalyzer.Attributes;
using QualRazorLib.Controls.Argments;
using QualRazorLib.Controls.Tables.Columns;
using QualRazorLib.Controls.Tables.Columns.Dtos;
using QualRazorLib.Core;
using QualRazorLib.Helpers;
using System.Linq.Expressions;

namespace QualRazorLib.Controls.Tables
{

    public partial class QualTableColumn<TModel> : QualRazorComponentBase, ITableColumnContent
    {
        [CascadingParameter(Name = CascadingParameterName.TableContentParent)]
        public QualTable<TModel> TableParent { get; set; } = default!;

        [Parameter, EditorRequired]
        public Func<Factory, IColumnState> StateFactory { get; set; } = default!;

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public TextAlignType Align { get; set; } = TextAlignType.Auto;

        [Parameter]
        public string? FormatString { get; set; }

        [CastCheck(typeof(PropertyAccessCore))]
        public IColumnState ColumnState { get; set; } = default!;

        [CascadingParameter,EditorRequired]
        public Type? TModelType { get; set; }

        public IColumnState ColumnStateBase => ColumnState;

        protected Dictionary<string, object> MergedAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                MergeAttributeBase,
                new()
                );

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (TableParent != null)
            {
                ColumnState = StateFactory.Invoke(new Factory());
                if(ColumnState is IColumnStateInitializer stateInitializer)
                {
                    stateInitializer.FormatString = FormatString;
                    stateInitializer.TextAlign = Align;
                }
                TableParent.AddColumn(this);
            }
        }

        protected override async Task OnLeftMouseClick(MouseKeyArg e)
        {//左クリックのみに反応
            await TableParent.ViewModel.LoadAsync();
            //StateHasChanged();
        }

        public RenderFragment RenderHeader() => builder =>
        {
            builder.OpenElement(0, HtmlAtributes.TH);
            builder.AddMultipleAttributes(1, MergedAttributes);
            builder.AddAttribute(2, HtmlAtributes.MOUSECLICK, EventCallback.Factory.Create<MouseEventArgs>(this, (e) => OnMouseClick(e)));
            if (ChildContent is null)
            {
                builder.AddContent(3, (MarkupString)ColumnState.PropertyName);
            }
            else
            {
                builder.AddContent(4, ChildContent);
            }
            builder.CloseElement();
        };

        public class Factory
        {
            public IColumnState? Create(Expression<Func<TModel, object>> propertyExpression)
            {
                
                if(propertyExpression.Body is MemberExpression memberExper)
                {
                    var type = memberExper.Type;
                    var param= propertyExpression.Parameters[0];
                    var lambdaType = typeof(Func<,>).MakeGenericType(typeof(TModel), type);
                    var lambda = Expression.Lambda(lambdaType, memberExper, param);
                    var columnstate= typeof(ColumnState<,>).MakeGenericType(typeof(TModel), type);
                    return (IColumnState)Activator.CreateInstance(columnstate, lambda)!;
                }
                // 1. UnaryExpressionを除去（objectにキャストされているため）
                if (propertyExpression.Body is UnaryExpression unary && unary.NodeType == ExpressionType.Convert)
                {
                    var memberExpr = unary.Operand as MemberExpression;
                    if (memberExpr == null)
                        throw new ArgumentException("Invalid property expression");

                    // 2. プロパティの型を取得
                    var propertyType = memberExpr.Type;

                    // 3. 式ツリーを Expression<Func<TModel, TProperty>> に変換
                    var parameter = propertyExpression.Parameters[0];
                    var lambdaType = typeof(Func<,>).MakeGenericType(typeof(TModel), propertyType);
                    var lambda = Expression.Lambda(lambdaType, memberExpr, parameter);

                    // 4. ColumnState<TModel, TProperty> を動的に生成
                    var columnStateType = typeof(ColumnState<,>).MakeGenericType(typeof(TModel), propertyType);
                    return (IColumnState)Activator.CreateInstance(columnStateType, lambda)!;
                }

                throw new ArgumentException("Only simple property accessors are supported.");
            }
        }
    }
}



