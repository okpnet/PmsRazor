using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.Tables.Columns.Core;
using QualRazorCore.Core;
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
        public string StringValue { get; set; } = string.Empty;

    }
}
