using QualRazorCore.Controls.Conditions;
using TalkLib.Expressions.Conditions;

namespace QualRazorCore.Controls.Conditions.Helpers
{
    public static class ConditionTypeHelper
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
        /// 条件ラベル辞書
        /// </summary>
        private static IReadOnlyDictionary<ConditionType, string> _conditionLabels = new Dictionary<ConditionType, string>
            {
                { ConditionType.EQ, EQ },
                { ConditionType.NEQ, NEQ },
                { ConditionType.IN, IN },
                { ConditionType.NIN, NIN },
                { ConditionType.SW, SW },
                { ConditionType.EW, EW },
                { ConditionType.NSW, NSW },
                { ConditionType.NEW, NEW },
                { ConditionType.LIK, LIK },
                { ConditionType.NLIK, NLIK },
                { ConditionType.LT, LT },
                { ConditionType.GT, GT },
                { ConditionType.LE, LE },
                { ConditionType.GE, GE }
            };
        /// <summary>
        /// 条件作成用の辞書
        /// </summary>
        private static readonly Dictionary<ConditionType, Func<object, ITalkCondition>> ConditionCreators = new()
        {
            // 単純条件
            [ConditionType.EQ] = v => new EqualCondition(v),
            [ConditionType.NEQ] = v => new EqualCondition(v) { IsNot = true },

            // 文字列条件
            [ConditionType.SW] = v => new StrStatwithCondtion(v),
            [ConditionType.NSW] = v => new StrStatwithCondtion(v) { IsNot = true },
            [ConditionType.EW] = v => new StrEndwithCondition(v),
            [ConditionType.NEW] = v => new StrEndwithCondition(v) { IsNot = true },
            [ConditionType.LIK] = v => new StrContainsCondition(v),
            [ConditionType.NLIK] = v => new StrContainsCondition(v) { IsNot = true },

            // 数値・比較
            [ConditionType.LT] = v => new LessCondition(v) { IsThanEqual = false },
            [ConditionType.LE] = v => new LessCondition(v) { IsThanEqual = true },
            [ConditionType.GT] = v => new GreaterCondition(v) { IsThanEqual = false },
            [ConditionType.GE] = v => new GreaterCondition(v) { IsThanEqual = true },

            // 列挙型条件
            [ConditionType.IN] = v => new ArrayContainsCondition(v),
            [ConditionType.NIN] = v => new ArrayContainsCondition(v) { IsNot = true },
        };
        /// <summary>
        ///文字列変換
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string ToStr(this ConditionType type) => _conditionLabels.TryGetValue(type, out var label) ? label : EQ;
        /// <summary>
        /// 文字列からTYPE変換
        /// </summary>
        /// <param name="typeString"></param>
        /// <returns></returns>
        public static ConditionType ConditionTypeFromStr(this string str)
        {
            var match = _conditionLabels.FirstOrDefault(kv => kv.Value == str);
            if (match.Equals(default(KeyValuePair<ConditionType, string>)))
                throw new ArgumentException($"Unknown condition string: {str}");

            return match.Key;
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
            type.ValidateEnumrableConditionAndValue(value);
            type.ValidateStringConditionAndValue(value);
            type.ValidateComparableConditionAndValue(value);
            if (!ConditionCreators.TryGetValue(type, out var creator))
            {
                throw new NotImplementedException($"ConditionType {type} is not supported.");
            }
            return creator(value);
        }
    }
}
