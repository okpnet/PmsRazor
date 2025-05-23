using Microsoft.AspNetCore.Components;
using QualRazorLib.Controls.Tables.Argments;
using QualRazorLib.Core;

namespace QualRazorLib.Controls.Tables.Informations
{
    public partial class PagenationButtonContent:QualRazorComponentBase
    {
        [CascadingParameter]
        public ITableInformationContent ParentTableInformation { get; set; } = default!;

        [Parameter, EditorRequired]
        public PagenationArg PagenationButton { get; set; } = default!;

        [Parameter, EditorRequired]
        public EventCallback<int> ChangeToPageNumber { get; set; } = default!;


        protected async Task OnChangePage()
        {
            await ChangeToPageNumber.InvokeAsync(PagenationButton.ChagePage());
        }
    }
}
