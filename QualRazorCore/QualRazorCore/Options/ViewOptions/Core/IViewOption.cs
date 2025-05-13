using QualRazorCore.Options.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Options.ViewOptions.Core
{
    public interface IViewOption : IOption
    {
        Dictionary<string, object> AdditionalAttributes { get; }
    }
}
