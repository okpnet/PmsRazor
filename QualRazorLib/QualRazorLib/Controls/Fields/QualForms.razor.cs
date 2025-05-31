using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using QualRazorLib.Core;

namespace QualRazorLib.Controls.Fields
{
    public partial class QualForms<TModel>:QualRazorComponentBase where TModel : class
    {
        protected EditForm _editForm = default!;

        protected EditContext? _editContext = default!;

        public const string CASCADE_PARAM = $"{nameof(QualForms<TModel>)}.Parent";

        [Parameter]
        public TModel Model { get; set; } = default!;

        [Parameter]
        public EventCallback<EditContext> OnValidSubmit { get; set; }

        [Parameter]
        public EventCallback<EditContext> OnInvalidSubmit { get; set; }

        [Parameter]
        public RenderFragment<TModel>? ChildContentWithModel { get; set; }

        [Parameter]
        public string FormName { get; set; }=Guid.NewGuid().ToString();


        protected override void OnInitialized()
        {
            base.OnInitialized();
            _editContext = new EditContext(Model!);
        }

        public bool Validate()=>_editContext?.Validate()??false;
    }
}
