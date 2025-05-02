using QualRazorCore.Controls.Filters;

namespace QualRazorCore.Controls.Tables.Columns.Core
{
    public interface ITableColumn
    {
        Guid Key { get; }

        SortType SortStatus { get; }
        Func<string> GetColumnNameInvoke { get; }
        TextArignType TextArign { get; }

        string ColumnName { get; }
    }

    public interface ITableColumn<TModel>: ITableColumn
    {
        Func<TModel, string> GetPropertyValueStringInvoke { get; }
    }
}
