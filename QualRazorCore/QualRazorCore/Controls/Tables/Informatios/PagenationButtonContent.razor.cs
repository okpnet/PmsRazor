using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.Tables.Argments;
using QualRazorCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Tables.Informatios
{
    public partial class PagenationButtonContent:RazorCore
    {
        [CascadingParameter]
        public ITableInformationContent ParentTableInformation { get; set; } = default!;

        [Parameter,EditorRequired]
        public PagenationArg PagenationButton { get; set; } = default!;

        [Parameter,EditorRequired]
        public EventCallback<int> ChangeToPageNumber { get; set; } = default!;


        protected async Task OnChangePage()
        {
            await ChangeToPageNumber.InvokeAsync(PagenationButton.ChagePage());
        }
    }
}
