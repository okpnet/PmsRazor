using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore
{
    public enum TextArignType
    {
        Center,
        Left,
        Right
    }

    public static class TextArignTypeHelper
    {
        public static string ToCssClasses(this TextArignType textArignType)
        {
            return textArignType switch
            {
                TextArignType.Left => ClassDefine.Text.LEFT,
                TextArignType.Right => ClassDefine.Text.RIGHT,
                TextArignType.Center => ClassDefine.Text.CENTER,
                _ => ""
            };
        }
    }
}
