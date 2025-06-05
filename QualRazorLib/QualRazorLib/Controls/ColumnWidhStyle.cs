using QualRazorLib.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Controls
{
    public enum ColumnWidhStyle:int
    {
        Per15=2,
        Per35=4,
        Half=6,
        Per65=8,
        Per80=10,
        Full=12
    }

    public static class ColumnWidhStyleHelper
    {
        private static ReadOnlyDictionary<int, string> CssColumnWidthClass = new(new Dictionary<int, string>()
        {
            [2]=$"{CssClasses.COLUMN_PER15}",
            [4]=$"{CssClasses.COLUMN_PER35}",
            [6]=$"{CssClasses.COLUMN_HALF}",
            [8]=$"{CssClasses.COLUMN_PER65}",
            [10]=$"{CssClasses.COLUMN_PER80}",
            [12]=$"{CssClasses.COLUMN_FULL}"
        });
        public static string CreateCssString(this ColumnWidhStyle style)
        {
            var colsize = (int)style;
            if(!CssColumnWidthClass.TryGetValue(colsize,out var result))
            {
                throw new NotImplementedException();
            }
            return result;
        }
    }
}