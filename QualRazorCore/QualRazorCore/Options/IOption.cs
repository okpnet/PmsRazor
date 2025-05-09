using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Options
{
    public interface IOption
    {
    }
    public interface IOption<TProperty>:IOption
    {
    }
}
