using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using QualRazorCore.Controls.Tables.Columns.Core;
using QualRazorCore.Controls.Tables.Options;
using QualRazorCore.Controls.Tables.Rows.Core;
using QualRazorCore.Core;
using QualRazorCore.Extenssions;
using QualRazorCore.Observers;

namespace QualRazorCore.Controls.Tables.Cells
{
    public partial class TableRowCellContent<TModel>:RazorCore where TModel : class
    {
        [CascadingParameter(Name = "CellOption"),EditorRequired]
        public TableCellOption Option { get; set; } = new();

        [Parameter, EditorRequired]
        public ITableColumn<TModel> Column { get; set; } = default!;

        [Parameter, EditorRequired]
        public TableRowState<TModel> Row { get; set; } = default!;


        protected Dictionary<string, object> MergedAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                Option.CellAdditionalAttributes,
                new([
                    new("class",Column.TextArign.ToCssClasses())
                    ])
                );


        string StringValue { get; set; } = string.Empty;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            disposables.Add(
                PropertyChangedRelay<TableRowState<TModel>, string>.Create(
                    Row,
                    nameof(Row.Model),
                    (rowState) => Column.GetPropertyValueStringInvoke(Row.Model),
                    (valueString)=>StringValue=valueString
                    )
                );
        }

    }
}

