﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Helpers
{
    public static class CommonExtension
    {
        /// <summary>
        /// キャストした値をOutにセットして､Null/非Nullを返す
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="value"></param>
        /// <param name="result">NullのときFalse/非NullのときTrue</param>
        /// <returns></returns>
        public static bool IsDeclare<TResult>(this TResult value, out TResult result)
        {
            result = value;
            return result is not null;
        }
        /// <summary>
        /// キャストした値をOutにセットして､値を返す
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static TResult IfDeclare<TResult>(this TResult value, out TResult result)
        {
            result = value;
            return result;
        }
    }
}
