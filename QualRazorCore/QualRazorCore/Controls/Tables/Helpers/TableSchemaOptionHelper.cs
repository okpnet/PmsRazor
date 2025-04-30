using QualRazorCore.Controls.Tables.Columns.Core;
using QualRazorCore.Controls.Tables.Options;
using QualRazorCore.Controls.Tables.Rows.Core;
using System.Linq.Expressions;

namespace QualRazorCore.Controls.Tables.Helpers
{
    public static class TableSchemaOptionHelper
    {
        public static ITableColumn<TModel> AddColumns<TModel,TProperty>(
            this TableSchemaOption<TModel> tables,
            string propertyName,
            Expression<Func<string>> columnNameExpression,
            Expression<Func<TModel,TProperty>> proertyExpression) where TModel : class
        {
            var column = new TableColumn<TModel,TProperty>(columnNameExpression, propertyName,proertyExpression);
            tables.Columns.Add(column);
            return column;
        }

        public static IEnumerable<TableRowState<TModel>> GenerateSource<TModel>(this TableSchemaOption<TModel> option) where TModel : class
        {
            if (!option.PageResult.Records.Any())
            {
                yield break;
            }
            foreach(var row in option.PageResult.Records.Select((model, index) =>
            {
                return new TableRowState<TModel>(index, model);
            }))
            {
                yield return row;
            }
        }
    }
}
