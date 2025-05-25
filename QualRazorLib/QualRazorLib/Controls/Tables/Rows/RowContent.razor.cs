using Microsoft.AspNetCore.Components;
using QualRazorLib.Controls.Tables.Columns.Dtos;
using QualRazorLib.Controls.Tables.Rows.Dtos;
using QualRazorLib.Core;
using QualRazorLib.Helpers;
using QualRazorLib.Observer;

namespace QualRazorLib.Controls.Tables.Rows
{
    public partial class RowContent<TModel> : QualRazorComponentBase
    {
        [CascadingParameter(Name = "TableContentParent")]
        public QualTable<TModel> TableParent { get; set; } = default!;

        [Parameter, EditorRequired]
        public TableRowState<TModel> Row { get; set; } = default!;

        protected IEnumerable<IColumnState> Columns => TableParent.Columns;

        protected RowStatus RowStatus { get; set; }

        protected Dictionary<string, object> MergedAttributes =>
        HtmlAttributeHelper.PurgeAttributes(
            MeargeAttributeBase,
            new()
            {
                [HtmlAtributes.CLASS] = Row.Status.HasFlag(RowStatus.Seleted) ? CssClasses.Table.ROW_SELECTED:"",
            });

        protected override void OnInitialized()
        {
            base.OnInitialized();
            RowStatus = Row.Status;
            PropertyChangedRelay<TableRowState<TModel>, RowStatus>.Create(Row,nameof(Row.Status),
                t=>t.Status,
                t=> RowStatus = t);
        }
    }
}
