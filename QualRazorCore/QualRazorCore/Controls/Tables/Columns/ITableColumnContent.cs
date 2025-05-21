using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.Filters;
using QualRazorCore.Controls.Tables.Parameters;

namespace QualRazorCore.Controls.Tables.Columns
{
    public interface ITableColumnContent
    {
        IColumnparameter Parameter { get; }

        SortType SortStatus { get; }

        RenderFragment RenderHeader();
    }
}
