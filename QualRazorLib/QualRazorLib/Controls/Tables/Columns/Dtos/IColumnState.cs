using QualRazorLib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public interface IColumnState<TModel, TResult> : IColumnState
    {
        Func<TModel, TResult> Getter { get; }
    }
}
