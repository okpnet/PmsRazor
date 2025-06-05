using Microsoft.AspNetCore.Components;
using QualRazorLib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Controls.Grids
{
    public partial class QualGridContainer: QualRazorComponentBase
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
