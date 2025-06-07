namespace QualRazorLib.Views.QueryConditions
{
    /// <summary>
    /// 第1位 否定の有効
    /// 第2位~第4位 条件の種類
    /// 第5位 文字列
    /// 第6位 数値
    /// 第7位 日付
    /// 第8位 二値
    /// </summary>
    [Flags]
    public enum ConditionType : int
    {
        Equal = 0b11110010,
        NotEqual = 0b11110011,
        In = 0b11110100,
        NotIn = 0b11110101,
        GreaterThan = 0b01100110,
        GreaterThanOrEqual = 0b01100111,
        LessThan = 0b01101000,
        LessThanOrEqual = 0b01101001,
        Contains = 0b00011010,
        NotContains = 0b00011011,
        StartWith = 0b00011100,
        EndWith = 0b00011101,
        Between = 0b01101110,
        NotBetween = 0b01101111,
    }

    public static class ConditionTypeHelper
    {
        private const int BitIsString = 0b00010000;
        private const int BitIsNumber = 0b00100000;
        private const int BitIsDate = 0b01000000;
        private const int BitIsBool = 0b10000000;
        private const int BitIsNot = 0b00000001;

        public static bool IsString(this ConditionType type) => ((int)type & BitIsString) == BitIsString;
        public static bool IsNumber(this ConditionType type) => ((int)type & BitIsNumber) == BitIsNumber;
        public static bool IsDateTime(this ConditionType type) => ((int)type & BitIsDate) == BitIsDate;
        public static bool IsBool(this ConditionType type) => ((int)type & BitIsBool) == BitIsBool;
        public static bool IsNot(this ConditionType type) => ((int)type & BitIsNot) == BitIsNot;
    }

}
