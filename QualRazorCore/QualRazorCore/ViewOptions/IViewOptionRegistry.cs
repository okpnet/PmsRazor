using QualRazorCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.ViewOptions
{
    public interface IViewOptionRegistry<IOptionKey, IViewOption> : IRegistry<IOptionKey, IViewOption> 
    {
    }
}
