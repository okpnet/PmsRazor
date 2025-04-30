using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.Tables.Columns.Core;
using QualRazorCore.Controls.Tables.Extensions;
using QualRazorCore.Controls.Tables.Informatios;
using QualRazorCore.Controls.Tables.Options;
using QualRazorCore.Controls.Tables.Rows.Core;
using QualRazorCore.Core;

namespace QualRazorCore.Controls.Tables
{
    public partial class TableContent<TModel>:RazorCore where TModel : class
    {
        /// <summary>
        /// エレメント参照
        /// </summary>
        protected TableInformationContent _informationContent=default!;

        [Parameter,EditorRequired]
        public TableSchemaOption<TModel> Option { get; set; } = default!;

        IEnumerable<ITableColumn<TModel>> Columns=>Option.Columns.OfType<ITableColumn<TModel>>();

        protected int NumberOfColumn => Columns.Count();


        protected IEnumerable<TableRowState<TModel>> Source { get; set; } = [];
        /// <summary>
        /// イベント中継インスタンス
        /// </summary>
        protected TableSchemaOptionNotifier<TModel> _notifier=default!; 

        protected override void OnInitialized()
        {
            _notifier = new(Option, (array) => Source = array);
        }
    }
}
