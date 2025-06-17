using QualRazorLib.Core;

namespace QualRazorLib.Controls.Tables.Columns.Dtos
{
    public interface IColumnState
    {
        string PropertyName { get; }

        Type PropertyValueType { get; }

        SortType SortStatus { get; }

        string? FormatString { get; }

        TextAlignType TextAlign { get; }

        string? GetStringFromValue<T>(T value);
    }

    public interface IColumnStateInitializer
    {
        string? FormatString { get; set; }

        TextAlignType TextAlign { get; set; }
    }

    public interface IColumnState<TModel, TResult> : IColumnState
    {
        Func<TModel, TResult> Getter { get; }
    }
}
