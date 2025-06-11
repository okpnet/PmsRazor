using Microsoft.AspNetCore.Components;
using QualRazorLib.Controls.Tables.Columns;
using QualRazorLib.Controls.Tables.Columns.Dtos;
using QualRazorLib.Core;
using QualRazorLib.Helpers;
using QualRazorLib.Presentation.Facades;
using QualRazorLib.Providers.Sources;
using System.Collections.ObjectModel;

namespace QualRazorLib.Controls.Tables
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public partial class QualTable<TModel>:QualRazorComponentBase where TModel : class
    {
        [Parameter,EditorRequired]
        public ITableViewModel<TModel> ViewModel { get; set; } = default!;

        public ITableDataProvider<TModel> DataProvider => ViewModel.Data;

        public IEnumerable<IColumnState> Columns => _columns.Select(t => t.ColumnStateBase);
        /// <summary>
        /// インフォメーションのレンダリング
        /// </summary>
        internal RenderFragment? PageInforamation { get; set; }
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

    }
}
