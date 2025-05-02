using QualRazorCore.Controls.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Tables.Columns.Core
{
    public interface IOrderChange
    {
        void OrderChange(SortType changeSortType);
    }
}
