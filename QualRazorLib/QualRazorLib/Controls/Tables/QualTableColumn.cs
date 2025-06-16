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
    public partial class QualTableColumn<TModel, TProperty> : QualRazorComponentBase, ITableColumnContent where TModel : class
    {
        [CascadingParameter(Name = CascadingParameterName.TableContentParent)]
        public QualTable<TModel> TableParent { get; set; } = default!;

        [Parameter, EditorRequired]
        public Expression<Func< TProperty>> Property { get; set; } = default!;

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public TextAlignType Align { get; set; } = TextAlignType.Auto;

        [Parameter]
        public string? FormatString { get; set; }

        [CastCheck(typeof(PropertyAccessCore))]
        public IColumnState<TModel, TProperty> ColumnState { get; set; } = default!;

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
                var converted = ExpressionHelper.Convert<TModel, TProperty>(Property);
                ColumnState = new ColumnState<TModel, TProperty>(converted)
                {
                    FormatString = FormatString,
                    TextAlign = Align,
                };
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
    }
}



