using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using QualRazorLib.Controls.Tables.Columns;
using QualRazorLib.Controls.Tables.Columns.Dtos;
using QualRazorLib.Core;
using QualRazorLib.Helpers;
using QualRazorLib.Presentation.Facades;
using QualRazorLib.Providers.Sources;
using System.Collections.ObjectModel;

namespace QualRazorLib.Controls.Tables
{
    public partial class QualTable<TModel>:QualRazorComponentBase where TModel : class
    {
        [Parameter,EditorRequired]
        public ITableViewModel<TModel> ViewModel { get; set; } = default!;

        public ITableDataProvider<TModel> DataProvider => ViewModel.Data;

        public IEnumerable<IColumnState> Columns => _columns.Select(t => t.ColumnStateBase);
        /// <summary>
        /// インフォメーションのレンダリング
        /// </summary>
        protected RenderFragment? PageInforamation { get; set; }
        /// <summary>
        /// 列
        /// </summary>
        protected ObservableCollection<ITableColumnContent> _columns { get; set; } = [];
        /// <summary>
        /// 列の数
        /// </summary>
        protected int NumberOfColumn => _columns.Count();
        /// <summary>
        /// 列追加
        /// </summary>
        /// <param name="column"></param>
        internal void AddColumn(ITableColumnContent column) => _columns.Add(column);

        protected Dictionary<string, object> MergedAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                MergeAttributeBase,
                new()
                {
                    [HtmlAtributes.CLASS] = CssClasses.Table.TABLE_CONTENT
                }
                );

        /// <summary>
        /// 列群のラッパー
        /// </summary>
        public class TableColumns : QualRazorComponentBase
        {
            [CascadingParameter(Name = "TableContentParent")]
            public QualTable<TModel> TableParent { get; set; } = default!;
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
        public class TablePagenations : QualRazorComponentBase
        {
            [CascadingParameter(Name = "TableContentParent")]
            public QualTable<TModel> TableParent { get; set; } = default!;
            [Parameter]
            public RenderFragment? ChildContent { get; set; }

            protected override void OnInitialized()
            {
                TableParent.PageInforamation = ChildContent;
            }
        }
    }
}
