using QualRazorCore.Options.Core;

namespace QualRazorCore.Options.ViewOptions.Core
{
    public class ViewOptionRegistry : RegistryCore<IOptionKey, IViewOption>,
        IViewOptionRegistry, IRegistry<IOptionKey, IViewOption>
    {

    }
}
