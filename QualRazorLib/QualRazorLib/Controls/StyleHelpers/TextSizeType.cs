using QualRazorLib.Helpers;

namespace QualRazorLib.Controls.StyleHelpers
{
    public enum TextSizeType : int
    {
        Normal = 0,
        Small = 7,
        Medium = 4,
        Large = 3,
    }

    public static class TextSizeTypeHelper
    {
        private static Dictionary<TextSizeType, string> _cssTextSizeType = new()
        {
            [TextSizeType.Normal] = CssClasses.TEXT_SIZE_6,
            [TextSizeType.Small] = CssClasses.TEXT_SIZE_7,
            [TextSizeType.Medium] = CssClasses.TEXT_SIZE_4,
            [TextSizeType.Large] = CssClasses.TEXT_SIZE_3,

        };

        public static string CreateCssString(this TextSizeType type) => _cssTextSizeType[type];
    }
}
