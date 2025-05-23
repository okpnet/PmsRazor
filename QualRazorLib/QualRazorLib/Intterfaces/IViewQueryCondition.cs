using QualRazorLib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Intterfaces
{
    public interface IViewQueryCondition
    {
        // 任意の型に変換して、ServiceやRepository層に渡す
        T ConvertTo<T>();
    }
}
