using Microsoft.AspNetCore.Components;
using QualRazorLib.Controls.Tables.Columns.Dtos;
using QualRazorLib.Controls.Tables.Rows.Dtos;
using QualRazorLib.Core;
using QualRazorLib.Helpers;
using QualRazorLib.Observer;

namespace QualRazorLib.Controls.Tables.Rows
{
    public partial class Row<TModel> : QualRazorComponentBase
    {
        [CascadingParameter(Name = "TableContentParent")]
        public QualTable<TModel> TableParent { get; set; } = default!;

        [Parameter, EditorRequired]
        public TableRowState<TModel> RowState { get; set; } = default!;

        protected IEnumerable<IColumnState> Columns => TableParent.Columns;

        protected RowStatus RowStatus { get; set; }

        protected Dictionary<string, object> MergedAttributes =>
        HtmlAttributeHelper.PurgeAttributes(
            MergeAttributeBase,
            new()
            {
                [HtmlAtributes.CLASS] = RowState.Status.HasFlag(RowStatus.Seleted) ? CssClasses.Table.ROW_SELECTED : "",
            });

        protected override void OnInitialized()
        {
            base.OnInitialized();
            RowStatus = RowState.Status;
            PropertyChangedRelay<TableRowState<TModel>, RowStatus>.Create(RowState, nameof(RowState.Status),
                t => t.Status,
                t => RowStatus = t);
        }
    }
}
