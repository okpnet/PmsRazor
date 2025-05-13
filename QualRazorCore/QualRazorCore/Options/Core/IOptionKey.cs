using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Options.Core
{
    public interface IOptionKey
    {
        string Name { get; }
        Type TargetType { get; }
    }
}
