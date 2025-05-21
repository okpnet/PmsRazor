using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using QualRazorCore.Controls.Filters;
using QualRazorCore.Controls.Tables.Columns;
using QualRazorCore.Controls.Tables.Parameters;
using QualRazorCore.Core;
using QualRazorCore.Extenssions;
using System.Linq.Expressions;

namespace QualRazorCore.Controls.Tables
{
    public class Column<TModel, TProperty> : RazorCore, ITableColumnContent where TModel : class
    {
        [CascadingParameter(Name = "TableContentParent")]
        public TableContent<TModel> TableParent { get; set; } = default!;

        [Parameter, EditorRequired]
        public Expression<Func<TModel, TProperty>> Property { get; set; } = default!;

        [Parameter]
        public RenderFragment? ChildContent { get; set; }


        public IColumnparameter Parameter => ColumnParameter;

        public SortType SortStatus { get; set; }

        protected ColumnParameter<TModel,TProperty> ColumnParameter { get; set; }= default!;

        protected Dictionary<string, object> MergedAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                MeargeAttributeBase,
                new()
                );


        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (TableParent != null)
            {
                ColumnParameter = new ColumnParameter<TModel, TProperty>(Property);
                TableParent.AddColumn(this);
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
            await TableParent.OnColumnLeftClick(this);

            StateHasChanged();
        }
        public RenderFragment RenderHeader() => builder =>
        {
            builder.OpenElement(0, "th");
            builder.AddMultipleAttributes(1, MergedAttributes);
            builder.AddAttribute(2, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, (e) => OnMouseClick(e)));
            if (ChildContent is null)
            {
                builder.AddContent(3, (MarkupString)Parameter.PropertyName);
            }
            else
            {
                builder.AddContent(4, ChildContent);
            }
            builder.CloseElement();
        };
    }
}
