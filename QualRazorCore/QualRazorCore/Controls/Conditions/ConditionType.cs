using TalkLib.Expressions.Conditions;

namespace QualRazorCore.Controls.Conditions
{
    /// <summary>
    /// 条件タイプ
    /// </summary>
    public enum ConditionType : byte
    {
        EQ = 0x0,
        NEQ = 0x1,
        IN = 0x2,
        NIN = 0x3,
        SW = 0x10,
        EW = 0x11,
        NSW = 0x12,
        NEW = 0x13,
        LIK = 0x14,
        NLIK = 0x15,
        LT = 0x20,
        GT = 0x21,
        LE = 0x22,
        GE = 0x23,
    }
}
