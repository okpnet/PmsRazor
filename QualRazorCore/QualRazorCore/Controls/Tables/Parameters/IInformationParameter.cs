using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.Tables.Argments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Tables.Parameters
{
    public interface IInformationParameter
    {
        bool IsSorted { get; }

        EventCallback<int> PageMoveInvoke { get; }

        EventCallback<ColumnChangeOrderArg> ChangeSortOrder { get; }

        int MaxNumberOfPage { get; }
    }
}
