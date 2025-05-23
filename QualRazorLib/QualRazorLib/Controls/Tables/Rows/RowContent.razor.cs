using Microsoft.AspNetCore.Components;
using QualRazorLib.Controls.Tables.Columns.Dtos;
using QualRazorLib.Controls.Tables.Rows.Dtos;
using QualRazorLib.Core;
using QualRazorLib.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Controls.Tables.Rows
{
    public partial class RowContent<TModel> : QualRazorComponentBase
    {
        [CascadingParameter(Name = "TableContentParent")]
        public QualTable<TModel> TableParent { get; set; } = default!;

        [Parameter, EditorRequired]
        public TableRowState<TModel> Row { get; set; } = default!;

        protected IEnumerable<IColumnState> Columns => TableParent.Columns;


        protected Dictionary<string, object> MergedAttributes =>
        HtmlAttributeHelper.PurgeAttributes(
            MeargeAttributeBase,
            new()
            );
    }
}
