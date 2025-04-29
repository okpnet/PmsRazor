using QualRazorCore.Controls.Tables.Columns.Core;
using QualRazorCore.Controls.Tables.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static QualRazorCore.ClassDefine;

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
    }
}
