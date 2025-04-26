namespace QualRazorCore.Controls
{
    [Flags]
    public enum FieldDataType:byte
    {
        None = 0,
        String=1<<0,
        Number=1<<1,
        Decimal=1<<2,
    }
}
