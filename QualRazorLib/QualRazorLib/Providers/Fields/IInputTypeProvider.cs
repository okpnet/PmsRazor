using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Providers.Fields
{
    public interface IInputTypeProvider
    {
        FieldDataType InputType { get; } // "text", "number", "date"など
    }
}
