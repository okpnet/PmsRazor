using QualRazorLib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Providers.Fields
{
    public class FieldProviderCore:NotifyCore,IInputTypeProvider
    {
        public virtual FieldDataType InputType { get; } = FieldDataType.None;
    }
}
