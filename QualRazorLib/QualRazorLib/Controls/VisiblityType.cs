using QualRazorLib.Helpers;

namespace QualRazorLib.Controls
{
    public enum VisiblityType
    {
        None,
        DesktopOnly,
        MobileOnly
    }

    public static class VisiblityTypeHelper
    {
        private static readonly Dictionary<VisiblityType, string> _cssVisiblityType = new()
        {
            [VisiblityType.None] ="",
            [VisiblityType.DesktopOnly]=CssClasses.STYLE_TO_HIDDEN_MOBILE,
            [VisiblityType.MobileOnly]=CssClasses.STYLE_TO_HIDDEN_DESKTOP
        };

        public static string CreateCssString(this VisiblityType type)=>_cssVisiblityType[type];
    }
}
