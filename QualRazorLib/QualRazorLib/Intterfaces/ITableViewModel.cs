using Microsoft.AspNetCore.Components;
using QualRazorLib.Controls.Tables.Argments;
using QualRazorLib.Controls.Tables.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Intterfaces
{
    public interface ITableViewModel<TModel>:IViewModel<TModel>
    {
        EventCallback<ITableColumnContent> AddColumn { get; set; }

        void ChangeSortOrder(string propertyName);
    }
}
