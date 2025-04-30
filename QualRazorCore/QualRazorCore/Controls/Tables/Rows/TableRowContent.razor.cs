using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.Tables.Columns.Core;
using QualRazorCore.Controls.Tables.Rows.Core;
using QualRazorCore.Core;

namespace QualRazorCore.Controls.Tables.Rows
{
    public partial class TableRowContent<TModel> : RazorCore where TModel : class
    {
        [Parameter, EditorRequired]
        public TableRowState<TModel> Row { get; set; } = default!;

        [Parameter, EditorRequired]
        public IEnumerable<ITableColumn<TModel>> Columns { get; set; } = default!;
    }
}
