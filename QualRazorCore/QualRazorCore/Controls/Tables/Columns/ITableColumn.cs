using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QualRazorCore.Containers;

namespace QualRazorCore.Controls.Tables.Columns
{
    public interface ITableColumn
    {
        Guid Key { get; }
    }

    public interface ITableColumn<TModel>
    {
        Func<TModel, string> GetPropertyValueInvoke { get; }
        Func<string> GetColumnNameInvoke { get; }
        TextArignType TextArign { get; }
    }
}
