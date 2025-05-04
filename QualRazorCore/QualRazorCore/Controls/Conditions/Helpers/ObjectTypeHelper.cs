using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Conditions.Helpers
{
    public static class ObjectTypeHelper
    {
        /// <summary>
        /// 文字列かどうか
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsString(this object value) => value is string;
        /// <summary>
        /// 列挙型かどうか
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEnumerable(this object value) => value is System.Collections.IEnumerable && value.GetType() != typeof(string);
        /// <summary>
        /// 比較可能かどうか
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsComparable(this object value) => !(value.IsString() || value.IsEnumerable());
    }
}
