using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QualRazorLib.Providers.Sources
{

    public interface ITreeStructureDataProvider<T>
    {
        ITreeNodeDataProvider<T> Root { get; }
    }
}
