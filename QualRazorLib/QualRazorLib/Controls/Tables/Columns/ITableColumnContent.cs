using Microsoft.AspNetCore.Components;
using QualRazorLib.Core;

namespace QualRazorLib.Controls.Tables.Columns
{
    public interface ITableColumnContent
    {
        PropertyAccessCore ColumnParameter { get; }

        SortType SortStatus { get; }

        RenderFragment RenderHeader();
    }
}
