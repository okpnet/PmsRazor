using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.Tables.Argments;
using QualRazorCore.Controls.Tables.Columns;
using TalkLib.Pages.Results.ResultItems;

namespace QualRazorCore.Controls.Tables.Parameters
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface ITableSchema<TModel> where TModel : class
    {
        ITalkPageResult<TModel>? Source { get; }

        EventCallback<ColumnChangeOrderArg>? ChangeSortOrder { get; }

        IEnumerable<IColumnparameter> Columns { get; }
    }
}
