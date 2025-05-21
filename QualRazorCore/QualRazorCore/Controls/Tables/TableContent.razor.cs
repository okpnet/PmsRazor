using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using QualRazorCore.Controls.Filters;
using QualRazorCore.Controls.Tables.Argments;
using QualRazorCore.Controls.Tables.Columns;
using QualRazorCore.Controls.Tables.Helpers;
using QualRazorCore.Controls.Tables.Informatios;
using QualRazorCore.Controls.Tables.Options;
using QualRazorCore.Controls.Tables.Parameters;
using QualRazorCore.Controls.Tables.Rows.Core;
using QualRazorCore.Core;
using QualRazorCore.Extenssions;
using QualRazorCore.Observers;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using TalkLib.Pages.Results.ResultItems;

namespace QualRazorCore.Controls.Tables
{
    public partial class TableContent<TModel>:RazorCore where TModel : class
    {
        /// <summary>
        /// エレメント参照
        /// </summary>
        protected TableInformationContent _informationContent=default!;

        protected ObservableCollection<ITableColumnContent> _columns { get; set; } = new();

        [Parameter,EditorRequired]
        public TableSchemaOption<TModel> Option { get; set; } = default!;

        [Parameter]
        public ITalkPageResult<TModel>? Source { get; set; }

        [Parameter]
        public EventCallback<ColumnChangeOrderArg>? ChangeSortOrder { get; set; }

        public IEnumerable<IColumnparameter> Columns=> _columns.Select(t=>t.Parameter);

        protected int NumberOfColumn => _columns.Count();

        internal void AddColumn(ITableColumnContent column)=> _columns.Add(column);

        protected Dictionary<string, object> MergedAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                MeargeAttributeBase,
                new()
                {
                    ["class"]=$"table is-fullwidth is-hoverable"
                }
                );

        protected override void OnInitialized()
        {
            disposables.Add(
                PropertyChangedRelay<TableSchemaOption<TModel>, IEnumerable<TableRowState<TModel>>>.Create
                (
                    Option,
                    nameof(Option.PageResult),
                    src => Option.GenerateSource(),
                    sources => Source=sources
                    )
                );
        }

        internal async Task OnColumnLeftClick(ITableColumnContent columnContent)
        {
            if(ChangeSortOrder is null)
            {
                return;
            }
            await ChangeSortOrder.Value.InvokeAsync(new ColumnChangeOrderArg(columnContent.Parameter.PropertyName, columnContent.SortStatus));
        }

        /// <summary>
        /// 列群のラッパー
        /// </summary>
        public class TableColumns:RazorCore
        {
            [CascadingParameter(Name = "TableContentParent")]
            public TableContent<TModel> TableParent { get; set; } = default!;
            [Parameter]
            public RenderFragment? ChildContent { get; set; }

            protected override void BuildRenderTree(RenderTreeBuilder builder)
            {
                builder.AddContent(0, ChildContent);
            }
        }
        /// <summary>
        /// ページネーションのラッパー
        /// </summary>
        public class TablePagenation : RazorCore
        {
            [CascadingParameter(Name = "TableContentParent")]
            public TableContent<TModel> TableParent { get; set; } = default!;
            [Parameter]
            public RenderFragment? ChildContent { get; set; }

            protected override void BuildRenderTree(RenderTreeBuilder builder)
            {
                builder.AddContent(0, ChildContent);
            }
        }
    }
}
