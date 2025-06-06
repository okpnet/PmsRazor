using Microsoft.AspNetCore.Components;
using QualRazorLib.Core;
using QualRazorLib.Helpers;

namespace QualRazorLib.Controls.Dialogs
{
    public partial class QualModalDialog:QualRazorComponentBase
    {
        protected TaskCompletionSource<DialogResult>? _taskCompletionSource = default!;

        [Parameter]
        public RenderFragment? DialogContents { get; set; }

        [Parameter]
        public RenderFragment? DialogTitle { get; set; }

        [Parameter]
        public EventCallback CloseBtnClick { get; set; }

        private string CssActive { get; set; } = "";
        internal PrimaryButtons? PrimaryButtonsContent { get; set; }
        internal SecondaryButtons? SecondaryButtonsContent { get; set; }
        internal TertiaryButtons? TertiaryButtonsContent { get; set; }

        protected Dictionary<string, object> MergeDialogAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                MergeAttributeBase,
                new()
                {
                    [HtmlAtributes.CLASS]=$"{CssClasses.STYLE_MODAL} {CssActive}"
                }
                );

        /// <summary>
        /// ダイアログ待機
        /// </summary>
        /// <param name="confirmDlgArg"></param>
        /// <returns></returns>
        public Task<DialogResult> ShowAsync()
        {
            IsShoing(true);
            _taskCompletionSource = new TaskCompletionSource<DialogResult>();
            StateHasChanged();
            return _taskCompletionSource.Task;
        }
        /// <summary>
        /// ダイアログ表示
        /// </summary>
        /// <param name="isShow"></param>
        void IsShoing(bool isShow) => CssActive = isShow ? CssClasses.SHOW_ACTIVE : "";

        protected void OnClose()
        {
            ArgumentNullException.ThrowIfNull(_taskCompletionSource);
            _taskCompletionSource.SetResult(DialogResult.Close);
            IsShoing(false);
        }

        protected void OnPrimaryClick()
        {
            ArgumentNullException.ThrowIfNull(_taskCompletionSource);
            _taskCompletionSource.SetResult(DialogResult.Primary);
            IsShoing(false);
        }

        protected void OnSecondaryClick()
        {
            ArgumentNullException.ThrowIfNull(_taskCompletionSource);
            _taskCompletionSource.SetResult(DialogResult.Secondary);
            IsShoing(false);
        }

        protected void OnTertiaryClick()
        {
            ArgumentNullException.ThrowIfNull(_taskCompletionSource);
            _taskCompletionSource.SetResult(DialogResult.Tertiary);
            IsShoing(false);
        }

        public class PrimaryButtons : QualRazorComponentBase
        {

            [CascadingParameter(Name = "Parent")]
            public QualModalDialog? Parent { get; set; }
            [Parameter]
            public bool IsMiniButton { get; set; } = false;

            [Parameter]
            public RenderFragment? ChildContent { get; set; }

            [Parameter]
            public string IconClass { get; set; } = string.Empty;

            protected override void OnInitialized()
            {
                base.OnInitialized();
                if (Parent is not null)
                {
                    Parent.PrimaryButtonsContent = this;
                }
            }
        }
        public class SecondaryButtons : QualRazorComponentBase
        {
            [CascadingParameter(Name = "Parent")]
            public QualModalDialog? Parent { get; set; }
            [Parameter]
            public bool IsMiniButton { get; set; } = false;
            [Parameter]
            public RenderFragment? ChildContent { get; set; }

            [Parameter]
            public string IconClass { get; set; } = string.Empty;

            protected override void OnInitialized()
            {
                base.OnInitialized();
                if (Parent is not null)
                {
                    Parent.SecondaryButtonsContent = this;
                }
            }
        }
        public class TertiaryButtons : QualRazorComponentBase
        {
            [CascadingParameter(Name = "Parent")]
            public QualModalDialog? Parent { get; set; }
            [Parameter]
            public bool IsMiniButton { get; set; } = false;
            [Parameter]
            public RenderFragment? ChildContent { get; set; }

            [Parameter]
            public string IconClass { get; set; } = string.Empty;
            protected override void OnInitialized()
            {
                base.OnInitialized();
                if (Parent is not null)
                {
                    Parent.TertiaryButtonsContent = this;
                }
            }
        }
    }
}
