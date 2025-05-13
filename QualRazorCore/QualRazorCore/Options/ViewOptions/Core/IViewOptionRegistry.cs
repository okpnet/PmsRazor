using QualRazorCore.Options.Core;
using System.Linq.Expressions;

namespace QualRazorCore.Options.ViewOptions.Core
{
    public interface IViewOptionRegistry : IRegistry<IOptionKey, IViewOption>
    {
    }
}
