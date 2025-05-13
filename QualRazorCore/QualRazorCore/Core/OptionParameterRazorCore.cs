using Microsoft.AspNetCore.Components;
using QualRazorCore.Options.Configurations.Core;
using QualRazorCore.Options.Core;
using QualRazorCore.Options.ViewOptions.Core;
using System.ComponentModel;

namespace QualRazorCore.Core
{
    public abstract class OptionParameterRazorCore: RazorCore, INotifyPropertyChanged, IDisposable
    {
        [Inject]
        public IViewOptionRegistry ViewOptionRegistryService { get; set; } = default!;

        [Inject]
        public IConfigOptionRegistry ConfigOptionRegistryService { get; set; } = default!;

        [CascadingParameter]
        public OptionParameterRazorCore? ParentContent { get; set; }

        [Parameter]
        public IOptionKey? ViewOptionKey { get; set; } = default!;

        [Parameter]
        public IOptionKey? ConfigOptionKey { get; set; } = default!;
        /// <summary>
        /// パラメーターのキーが割り当てられないときに、デフォルトの型のキーを使用してViewOptionを取得する
        /// </summary>
        protected virtual IOptionKey DefaultViewOptionKey { get; } = default!;

        protected virtual IViewOption? ViewOptions => 
            ViewOptionKey is null ? ViewOptionRegistryService.Resolve(DefaultViewOptionKey) : ViewOptionRegistryService.Resolve(ViewOptionKey);

    }
}
