using Microsoft.AspNetCore.Components;
using QualRazorCore.Options.Core;
using QualRazorCore.Options.Registration;
using System.ComponentModel;

namespace QualRazorCore.Core
{
    public abstract class OptionParameterRazorCore: RazorCore, INotifyPropertyChanged, IDisposable
    {
        [Inject]
        public IOptionRegistry OptionRegistryService { get; set; } = default!;

        [Parameter]
        public IOptionKey OptionKey { get; set; } = default!;

        protected IOption? BaseOptions => OptionRegistryService.Resolve(OptionKey);
    }
}
