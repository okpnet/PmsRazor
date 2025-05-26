using QualRazorLib.Helpers;

namespace QualRazorLib.Controls.Buttons
{
    public enum LayerType
    {
        Primary,
        Secondary,
        Tertiary
    }

    public static class LayerTypeHelper
    {
        public static string? ToCssClasses(this LayerType layerType)
        {
            return layerType switch
            {
                LayerType.Primary => CssClasses.Button.PRIMARY,
                LayerType.Secondary => CssClasses.Button.SECONDARY,
                LayerType.Tertiary => CssClasses.Button.TERTIARY,
                _ => null
            };
        }
    }
}
