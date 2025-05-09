using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Options.Registry
{
    public interface IOptionKey
    {
        string Name { get; }
        Type ValueType { get; }
    }

    public interface IOptionKey<T> : IOptionKey
    {
    }
}
