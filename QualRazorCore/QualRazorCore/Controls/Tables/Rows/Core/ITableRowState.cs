using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Tables.Rows.Core
{
    public interface ITableRowState
    {
        Guid Key { get; }
        RowStatus Status { get; }

        int RowIndex { get; }
    }

    public interface ITableRowState<TModel> : ITableRowState
    {
        TModel Model { get; }
    }

}
