using QualRazorLib.Helpers;

namespace QualRazorLib.Controls.StyleHelpers
{
    public enum TextBoldType
    {
        None,
        Thin,
        SemiBold,
        Bold,
    }

    public static class TextBoldTypeHelper
    {
        private static Dictionary<TextBoldType, string> _cssTextBoldType = new()
        {
            [TextBoldType.None] = "",
            [TextBoldType.Thin] = CssClasses.TEXT_THIN_THICKNESS,
            [TextBoldType.SemiBold] = CssClasses.TEXT_SEMIBOLD_THICKNESS,
            [TextBoldType.Bold] = CssClasses.TEXT_BOLD_THICKNESS
        };

        public static string CreateCssString(this TextBoldType type) => _cssTextBoldType[type];
    }
}
