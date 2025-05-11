using Microsoft.AspNetCore.Components;
using QualRazorCore.Core;
using QualRazorCore.Options.Core;
using QualRazorCore.Options.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Fields
{
    public partial class FieldContent:RazorCore
    {
        [Inject]
        public IOptionRegistry OptionRegistry { get; set; } = default!;

        [Parameter]
        public string Name { get; set; } = string.Empty;

        [Parameter, EditorRequired]
        public IOptionKey OptionKey { get; set; } = default!;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ArgumentNullException.ThrowIfNull(OptionKey);

        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            OptionRegistry.Resolve()
        }
    }
}
