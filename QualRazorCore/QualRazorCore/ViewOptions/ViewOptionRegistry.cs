using QualRazorCore.Core;

namespace QualRazorCore.ViewOptions
{
    public class ViewOptionRegistry: RegistryCore<IOptionKey, IViewOption>, 
        IViewOptionRegistry<IOptionKey,IViewOption>,
        IRegistry<IOptionKey, IViewOption> 
    {
    }
}
