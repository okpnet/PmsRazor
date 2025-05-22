using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using QualRazorLib.Argments;
using QualRazorLib.Controls.Tables;
using QualRazorLib.Controls.Tables.Columns;
using QualRazorLib.Core;
using QualRazorLib.Helpers;
using System.Linq.Expressions;

namespace QualRazorCore.Controls.Tables
{
    public class Column<TModel, TProperty> : QualRazorComponentBase, ITableColumnContent where TModel : class
    {
        [CascadingParameter(Name = "TableContentParent")]
        public QualTable<TModel> TableParent { get; set; } = default!;

        [Parameter, EditorRequired]
        public Expression<Func<TModel, TProperty>> Property { get; set; } = default!;

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        public SortType SortStatus { get; set; }

        public PropertyAccessCore ColumnParameter { get; set; }= default!;

        protected Dictionary<string, object> MergedAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                MeargeAttributeBase,
                new()
                );

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            if (TableParent != null)
            {
                ColumnParameter = new PropertyAccessCore<TModel, TProperty>(Property);
                await TableParent.TableViewModel.AddColumn.InvokeAsync(this);
            }
        }

        protected override async Task OnLeftMouseClick(MouseKeyArg e)
        {//左クリックのみに反応

            var changeOrderType = SortStatus switch
            {
                SortType.None => SortType.ASC,
                SortType.ASC => SortType.DESC,
                SortType.DESC => SortType.None,
                _ => SortType.None,
            };
            TableParent.TableViewModel.ChangeSortOrder(ColumnParameter.PropertyName);
            StateHasChanged();
        }

        public RenderFragment RenderHeader() => builder =>
        {
            builder.OpenElement(0, HtmlAtributes.TH);
            builder.AddMultipleAttributes(1, MergedAttributes);
            builder.AddAttribute(2, HtmlAtributes.MOUSECLICK, EventCallback.Factory.Create<MouseEventArgs>(this, (e) => OnMouseClick(e)));
            if (ChildContent is null)
            {
                builder.AddContent(3, (MarkupString)ColumnParameter.PropertyName);
            }
            else
            {
                builder.AddContent(4, ChildContent);
            }
            builder.CloseElement();
        };
    }
}
