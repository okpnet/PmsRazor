using QualRazorCore.Containers;
using QualRazorCore.Controls.Filters;

namespace QualRazorCore.Controls.Tables.Columns
{
    public interface ITableColumn
    {
        Guid Key { get; }

        SortType SortStatus { get; }
    }

    public interface ITableColumn<TModel>: ITableColumn
    {
        Func<TModel, string> GetPropertyValueStringInvoke { get; }
        Func<string> GetColumnNameInvoke { get; }
        TextArignType TextArign { get; }
    }
}
