using Microsoft.AspNetCore.Components;
using QualRazorLib.Controls.Tables.Columns.Dtos;

namespace QualRazorLib.Controls.Tables.Columns
{
    public interface ITableColumnContent
    {
        IColumnState ColumnStateBase { get; }

        RenderFragment RenderHeader();
    }
}
