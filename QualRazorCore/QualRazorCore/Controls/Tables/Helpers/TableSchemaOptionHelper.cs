using QualRazorCore.Controls.Tables.Columns;
using QualRazorCore.Controls.Tables.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QualRazorCore.ClassDefine;

namespace QualRazorCore.Controls.Tables.Helpers
{
    public static class TableSchemaOptionHelper
    {
        public static ITableColumn<TModel> AddColumns<TModel>(this TableSchemaOption<TModel> tables, Func<TModel, string> getValueString, Func<string> columnName, Type propertyType, uint index)
        {
            var column = new TableColumn<TModel>(getValueString, columnName, propertyType);
            tables.Columns.Add(column);
            return column;
        }
    }
}
