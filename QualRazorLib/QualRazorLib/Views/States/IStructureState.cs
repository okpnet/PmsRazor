using QualRazorLib.Providers.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Views.States
{
    public interface IStructureState<T>
    {
        T? Parent { get; }

        void SetParent(T? newParent);
    }
}
