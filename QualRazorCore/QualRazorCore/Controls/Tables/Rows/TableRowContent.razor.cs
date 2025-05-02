using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.Tables.Columns.Core;
using QualRazorCore.Controls.Tables.Options;
using QualRazorCore.Controls.Tables.Rows.Core;
using QualRazorCore.Core;
using QualRazorCore.Extenssions;

namespace QualRazorCore.Controls.Tables.Rows
{
    public partial class TableRowContent<TModel> : RazorCore where TModel : class
    {
        [Parameter, EditorRequired]
        public TableRowState<TModel> Row { get; set; } = default!;

        [Parameter, EditorRequired]
        public IEnumerable<ITableColumn<TModel>> Columns { get; set; } = default!;

        [Parameter,EditorRequired]
        public TableRowOption Option { get; set; } = default!;

        protected Dictionary<string, object> MergedAttributes =>
        HtmlAttributeHelper.PurgeAttributes(
            Option.RowAdditionalAttributes,
            new([
                ])
            );
    }
}
