namespace QualRazorLib.Controls.Argments
{
    public class MouseKeyArg
    {
        public bool IsShiftKey { get; }

        public bool IsAltKey { get; }

        public MouseKeyArg(bool isShiftKey, bool isAltKey)
        {
            IsShiftKey = isShiftKey;
            IsAltKey = isAltKey;
        }
    }
}
