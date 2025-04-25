using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Containers.Core
{
    public interface IHeaderColumn
    {
        Guid Key { get; }
    }

    public interface IHeaderColumn<TModel>
    {
        Func<TModel, string> GetPropertyValueInvoke { get; }
        Func<string> GetColumnNameInvoke { get; }
        TextArignType TextArign { get; }
    }
}
