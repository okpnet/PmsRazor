using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using QualAnalyzer.Attributes;
using QualRazorLib.Controls.Tables.Columns;
using QualRazorLib.Controls.Tables.Columns.Dtos;
using QualRazorLib.Core;
using QualRazorLib.Helpers;
using QualRazorLib.Models.Tables;
using QualRazorLib.Presentation.Facades;
using System.Collections.ObjectModel;

namespace QualRazorLib.Controls.Tables
{
    public partial class QualTable<TModel>:QualRazorComponentBase where TModel : class
    {
        /// <summary>
        /// アクセス
        /// </summary>
        [Parameter,EditorRequired,CastCheck(typeof(ITableViewModel<>))]
        public ITableViewParameter Parameter { get; set; } = default!;

        public ITableViewModel<TModel> ViewModel=> (ITableViewModel<TModel>)Parameter;

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
                MeargeAttributeBase,
                new()
                {
                    [HtmlAtributes.CLASS] = CssClasses.Table.TABLE_CONTENT
                }
                );

        protected override void OnParametersSet()
        {
            ArgumentNullException.ThrowIfNull(Parameter);
        }

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
