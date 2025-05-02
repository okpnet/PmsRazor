using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using QualRazorCore.Controls.Tables.Columns.Core;
using QualRazorCore.Controls.Tables.Options;
using QualRazorCore.Controls.Tables.Rows.Core;
using QualRazorCore.Core;
using QualRazorCore.Extenssions;

namespace QualRazorCore.Controls.Tables.Cells
{
    public partial class TableRowEditCellContent<TModel>:RazorCore where TModel : class
    {
        EditContext _context=default!;

        [Parameter, EditorRequired]
        public TableRowState<TModel> Row { get; set; } = default!;

        [Parameter, EditorRequired]
        public IEnumerable<ITableColumn<TModel>> Columns { get; set; } = default!;

        int ColumnsCount => Columns.Count();

        [CascadingParameter(Name = "CellOption"), EditorRequired]
        public TableCellOption Option { get; set; } = new();

        Dictionary<string, object> MergeAttribue => HtmlAttributeHelper.PurgeAttributes(
            Option.CellAdditionalAttributes,
            new([
                new("colspan", ColumnsCount.ToString())
                ])
            );

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _context = new(Row.Model);
        }
    }
}
