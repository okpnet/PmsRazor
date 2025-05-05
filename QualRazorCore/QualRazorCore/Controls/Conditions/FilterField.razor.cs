using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.Conditions.Options;
using QualRazorCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Conditions
{
    public partial class FilterField:RazorCore
    {
        [Parameter]
        public FilterOption Option { get; set; } = new();
    }
}
