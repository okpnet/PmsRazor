using QualRazorCore.Controls.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Conditions.Helpers
{
    public static class ConditionTypeValidator
    {
        /// <summary>
        /// 文字列条件かどうか
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsStringCondition(this ConditionType type) => type switch
        {
            ConditionType.SW or ConditionType.EW or ConditionType.NSW or ConditionType.NEW or ConditionType.LIK or ConditionType.NLIK => true,
            _ => false
        };
        /// <summary>
        /// 数値比較条件かどうか
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsComparableCondition(this ConditionType type) => type switch
        {
            ConditionType.LT or ConditionType.LE or ConditionType.GT or ConditionType.GE => true,
            _ => false
        };
        /// <summary>
        /// 等価条件かどうか
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsEqualableCondition(this ConditionType type) => type == ConditionType.EQ || type == ConditionType.NEQ;
        /// <summary>
        /// 列挙型条件かどうか
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsEnumrableCondition(this ConditionType type) => type switch
        {
            ConditionType.IN or ConditionType.NIN => true,
            _ => false
        };
        /// <summary>
        /// 列挙型条件かどうか
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool ValidateEnumrableConditionAndValue(this ConditionType type, object value)
        {
            if (value.IsEnumerable() != type.IsEnumrableCondition())
            {
                throw new ArgumentException("When value is an array, ConditionType must be IN or NIN.");
            }
            return true;
        }
        /// <summary>
        /// 文字列条件かどうか
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool ValidateStringConditionAndValue(this ConditionType type, object value)
        {
            if (type.IsEqualableCondition())
            {
                return true;
            }

            var isString = value.IsString();
            if (isString && !type.IsStringCondition())
            {
                throw new ArgumentException($"ConditionType '{type}' is not allowed for string type values.");
            }
            else if (!isString && type.IsStringCondition())
            {
                throw new ArgumentException($"ConditionType '{type}' is not allowed for non-string type values.");
            }
            return true;
        }
        /// <summary>
        /// 数値比較条件かどうか
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool ValidateComparableConditionAndValue(this ConditionType type, object value)
        {
            if (type.IsEqualableCondition())
            {
                return true;
            }
            var isComparable = value.IsComparable();
            if (isComparable && !type.IsComparableCondition())
            {
                throw new ArgumentException($"ConditionType '{type}' is not allowed for comparable values.");
            }
            else if (!isComparable && type.IsComparableCondition())
            {
                throw new ArgumentException($"ConditionType '{type}' requires a comparable value like number or date.");
            }
            return true;
        }
    }
}
