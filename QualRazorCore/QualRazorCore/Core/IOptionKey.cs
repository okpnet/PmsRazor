using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Core
{
    public interface IOptionKey
    {
        string Name { get; }
        Type TargetType { get; }
    }

    public interface IOptionKey<T> : IOptionKey
    {
    }
}
