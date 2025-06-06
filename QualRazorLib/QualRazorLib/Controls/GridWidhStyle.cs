using QualRazorLib.Helpers;
using System.Collections.ObjectModel;

namespace QualRazorLib.Controls
{
    public enum GridWidhStyle:int
    {
        Per15=2,
        Per35=4,
        Half=6,
        Per65=8,
        Per80=10,
        Full=12
    }

    public static class GridWidhStyleHelper
    {
        private readonly static ReadOnlyDictionary<int, string> _cssGridWidthClass = new(new Dictionary<int, string>()
        {
            [2]=$"{CssClasses.COLUMN_PER15}",
            [4]=$"{CssClasses.COLUMN_PER35}",
            [6]=$"{CssClasses.COLUMN_HALF}",
            [8]=$"{CssClasses.COLUMN_PER65}",
            [10]=$"{CssClasses.COLUMN_PER80}",
            [12]=$"{CssClasses.COLUMN_FULL}"
        });
        public static string CreateCssString(this GridWidhStyle style)
        {
            var colsize = (int)style;
            if(!_cssGridWidthClass.TryGetValue(colsize,out var result))
            {
                throw new NotImplementedException();
            }
            return result;
        }
    }
}