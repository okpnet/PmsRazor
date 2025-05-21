using QualRazorCore.Controls.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Tables.Argments
{
    public sealed class ColumnChangeOrderArg
    {
        public string PropertyName { get; }

        public SortType SortType { get; }

        public ColumnChangeOrderArg(string propertyName, SortType sortType)
        {
            PropertyName = propertyName;
            SortType = sortType;
        }
    }
}
