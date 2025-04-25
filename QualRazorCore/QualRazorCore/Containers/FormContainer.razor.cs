using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using QualRazorCore.Containers.Argments;
using QualRazorCore.Core;

namespace QualRazorCore.Containers
{
    public partial class FormContainer<TModel>:RazorCore
    {
        EditForm _editform=default!;

        [Parameter]
        public TModel Model { get; set; } = default!;

        [Parameter, EditorRequired]
        public RenderFragment<FormContentArg<TModel>> FormContent { get; set; } = default!;

        [Parameter,EditorRequired]
        public EventCallback<EditContext> SubmitEvent { get; set; } = EventCallback<EditContext>.Empty!;

        [Parameter]
        public RenderFragment? SaveButtonContetn { get; set; }

        [Parameter]
        public RenderFragment? EditTitleContent { get; set; } 


        protected async Task OnSaveClickAsync()
        {
            await SubmitEvent.InvokeAsync(_editform.EditContext);
        }
    }
}
