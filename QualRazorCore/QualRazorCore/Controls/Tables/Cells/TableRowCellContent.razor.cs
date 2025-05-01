using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.Tables.Columns.Core;
using QualRazorCore.Controls.Tables.Rows.Core;
using QualRazorCore.Core;
using QualRazorCore.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Tables.Cells
{
    public partial class TableRowCellContent<TModel>:RazorCore where TModel : class
    {
        [Parameter, EditorRequired]
        public ITableColumn<TModel> Column { get; set; } = default!;

        [Parameter, EditorRequired]
        public TableRowState<TModel> Row { get; set; } = default!;

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

