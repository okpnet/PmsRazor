using Microsoft.AspNetCore.Components;
using QualRazorCore.Core;
using QualRazorCore.Options.Provider;
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
        public OptionRegistry OptionRegistry { get; set; } = default!;

        [Parameter]
        public string Name { get; set; } = string.Empty;

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            OptionRegistry.Resolve()
        }
    }
}
