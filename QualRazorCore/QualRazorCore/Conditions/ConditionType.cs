using System.Text.Json.Serialization;
using TalkLib.Expressions.Conditions;

namespace TalkViewLib.Types
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
    public enum ConditionSelectableType : byte
    {
        BOOL = 0b0,
        NUM = 0b1,
        STR = 0b10,
    }
    /// <summary>
    /// 拡張クラス
    /// </summary>
    public static class ConditionTypeEx
    {
        public const string EQ = "Equal";
        public const string NEQ = "NotEqual";
        public const string IN = "In";
        public const string NIN = "NotIn";
        public const string SW = "StartWith";
        public const string EW = "EndWith";
        public const string NSW = "NotStartWith";
        public const string NEW = "NotEndWith";
        public const string LIK = "Like";
        public const string NLIK = "NotLike";
        public const string LT = "LessThan";
        public const string GT = "GreaterThan";
        public const string LE = "LessEqual";
        public const string GE = "GreaterEqual";
        /// <summary>
        ///文字列変換
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string ToStr(this ConditionType type)
        {
            switch (type)
            {
                case ConditionType.EQ:
                    return EQ;
                case ConditionType.NEQ:
                    return NEQ;
                case ConditionType.IN:
                    return IN;
                case ConditionType.NIN:
                    return NIN;
                case ConditionType.SW:
                    return SW;
                case ConditionType.EW:
                    return EW;
                case ConditionType.NSW:
                    return NSW;
                case ConditionType.NEW:
                    return NEW;
                case ConditionType.LIK:
                    return LIK;
                case ConditionType.NLIK:
                    return NLIK;
                case ConditionType.LT:
                    return LT;
                case ConditionType.GT:
                    return GT;
                case ConditionType.LE:
                    return LE;
                case ConditionType.GE:
                    return GE;
                default:
                    return EQ;
            }
        }
        /// <summary>
        /// 文字列からTYPE変換
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static ConditionType CondtionTypeFromStr(this string type)
        {
            switch (type)
            {
                case EQ:
                    return ConditionType.EQ;
                case NEQ:
                    return ConditionType.NEQ;
                case IN:
                    return ConditionType.IN;
                case NIN:
                    return ConditionType.NIN;
                case SW:
                    return ConditionType.SW;
                case EW:
                    return ConditionType.EW;
                case NSW:
                    return ConditionType.NSW;
                case NEW:
                    return ConditionType.NEW;
                case LIK:
                    return ConditionType.LIK;
                case NLIK:
                    return ConditionType.NLIK;
                case LT:
                    return ConditionType.LT;
                case GT:
                    return ConditionType.GT;
                case LE:
                    return ConditionType.LE;
                case GE:
                    return ConditionType.GE;
                default:
                    return ConditionType.EQ;
            }
        }
        /// <summary>
        /// 条件作成
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static ITalkCondition CreateCondition(this ConditionType type, object value)
        {
            if (value.GetType().IsArray)
            {
                if (type == ConditionType.IN)
                {
                    return new ArrayContainsCondition(value);
                }
                else if (type == ConditionType.NIN)
                {
                    return new ArrayContainsCondition(value) { IsNot = true };
                }
                throw new ArgumentException("When, object is array type ,Condtion type has to \"in\" or \"not in\".");
            }
            else if (type == ConditionType.EQ)
            {
                return new EqualCondition(value);
            }
            else if (type == ConditionType.NEQ)
            {
                return new EqualCondition(value) { IsNot = true };
            }
            else if (value.GetType() == typeof(string))
            {
                switch (type)
                {
                    case ConditionType.SW:
                        return new StrStatwithCondtion(value);
                    case ConditionType.EW:
                        return new StrEndwithCondition(value);
                    case ConditionType.NSW:
                        return new StrStatwithCondtion(value) { IsNot = true };
                    case ConditionType.NEW:
                        return new StrEndwithCondition(value) { IsNot = true };
                    case ConditionType.LIK:
                        return new StrContainsCondition(value);
                    case ConditionType.NLIK:
                        return new StrContainsCondition(value) { IsNot = true };
                }
            }
            else
            {
                switch (type)
                {
                    case ConditionType.LT:
                        return new LessCondition(value) { IsThanEqual = false };
                    case ConditionType.GT:
                        return new GreaterCondition(value) { IsThanEqual = false };
                    case ConditionType.LE:
                        return new LessCondition(value) { IsThanEqual = true };
                    case ConditionType.GE:
                        return new GreaterCondition(value) { IsThanEqual = true };
                }
            }
            throw new NotImplementedException("Condition type is unknown.");
        }
        /// <summary>
        /// 選択可能な
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static ConditionSelectableType GetConditionSelectableType(this Type type)
        {
            byte typeByte = 0b0;
            if (type == typeof(bool)) typeByte = 0b0000;
            if (type == typeof(char)) typeByte = 0b0000;

            if (type == typeof(byte)) typeByte = 0b0001;
            if (type == typeof(sbyte)) typeByte = 0b0001;
            if (type == typeof(int)) typeByte = 0b0001;
            if (type == typeof(uint)) typeByte = 0b0001;
            if (type == typeof(short)) typeByte = 0b0001;
            if (type == typeof(ushort)) typeByte = 0b0001;
            if (type == typeof(long)) typeByte = 0b0001;
            if (type == typeof(ulong)) typeByte = 0b0001;
            if (type == typeof(float)) typeByte = 0b0001;
            if (type == typeof(double)) typeByte = 0b0001;
            if (type == typeof(decimal)) typeByte = 0b0001;
            if (type == typeof(DateTime)) typeByte = 0b0001;
            if (type == typeof(DateTimeOffset)) typeByte = 0b0001;
            if (type == typeof(TimeSpan)) typeByte = 0b0001;

            if (type == typeof(string)) typeByte = 0b0010;
            return (ConditionSelectableType)typeByte;
        }
        /// <summary>
        /// タイプから選択可能な条件リスト
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<ConditionType> GetSelectableTypes(this Type type)
        {
            switch ((byte)GetConditionSelectableType(type))
            {
                case 0b1:
                    return new ConditionType[] { ConditionType.EQ, ConditionType.NEQ, ConditionType.GE, ConditionType.LE, ConditionType.GT, ConditionType.LT, ConditionType.IN, ConditionType.NIN };
                case 0b10:
                    return new ConditionType[] { ConditionType.EQ, ConditionType.NEQ, ConditionType.LIK, ConditionType.NLIK, ConditionType.SW, ConditionType.NSW, ConditionType.EW, ConditionType.NEW, ConditionType.IN, ConditionType.NIN };
                case 0b0:
                    return new ConditionType[] { ConditionType.EQ, ConditionType.NEQ };
            }
            return new ConditionType[] { ConditionType.EQ };
        }
    }

}
