using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Controls.Tables.Informations
{
    public interface ITableInformationContent
    {
        RenderFragment RenderInformation();

        RenderFragment? PrevContent { get;  }

        RenderFragment? NextContent { get;  }
    }
}
