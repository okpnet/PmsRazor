using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Tables.Informatios
{
    public interface ITableInformationContent
    {
        RenderFragment RenderInformation();

        RenderFragment? PrevContent { get;  }

        RenderFragment? NextContent { get;  }
    }
}
