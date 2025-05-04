using QualRazorCore.Controls.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Conditions.Helpers
{
    public static class ConditionSelectableTypeHelper
    {
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
            IEnumerable<ConditionType> result = (byte)type.GetConditionSelectableType() switch
            {
                0b1 => [ConditionType.EQ, ConditionType.NEQ, ConditionType.GE, ConditionType.LE, ConditionType.GT, ConditionType.LT, ConditionType.IN, ConditionType.NIN],
                0b10 => [ConditionType.EQ, ConditionType.NEQ, ConditionType.LIK, ConditionType.NLIK, ConditionType.SW, ConditionType.NSW, ConditionType.EW, ConditionType.NEW, ConditionType.IN, ConditionType.NIN],
                0b0 => [ConditionType.EQ, ConditionType.NEQ],
                _ => [ConditionType.EQ]
            };
            return result;
        }
    }
}
