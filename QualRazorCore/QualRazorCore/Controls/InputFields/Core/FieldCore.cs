using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using QualRazorCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.InputFields.Core
{
    public class FieldCore:RazorCore
    {
        [CascadingParameter]
        protected EditContext? CascadedEditContext { get; set; }

        [Parameter]
        public RenderFragment PreContent { get; set; } = default!;

        [Parameter]
        public RenderFragment LabelContent { get; set; } = default!;
    }
}
