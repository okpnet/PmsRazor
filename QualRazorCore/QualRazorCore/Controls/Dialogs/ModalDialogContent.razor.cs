using Microsoft.AspNetCore.Components;
using QualRazorCore.Core;
using QualRazorCore.Extenssions;
using QualRazorCore.Options.Defaults;

namespace QualRazorCore.Controls.Dialogs
{
    public partial class ModalDialogContent:OptionParameterRazorCore
    {
        protected TaskCompletionSource<bool>? _taskCompletionSource = default!;

        [Parameter]
        public RenderFragment? DialogContents { get; set; }

        [Parameter]
        public string DialogTitle { get; set; } = string.Empty;

        [Parameter]
        public RenderFragment? PrimaryButtonContent { get; set; }

        [Parameter]
        public RenderFragment? PrimaryButtonIconContent { get; set; }

        [Parameter]
        public RenderFragment? SecondaryButtonContent { get; set; }

        [Parameter]
        public RenderFragment? SecondaryButtonIconContent { get; set; }

        [Parameter]
        public RenderFragment? TertiaryButtonContent { get; set; }

        [Parameter]
        public RenderFragment? TertiaryButtonIconContent { get; set; }

        [Parameter]
        public bool PrimarySubmitButton { get; set; }
        /// <summary>
        /// 取得したOptionをModalDialogOptionに変更する
        /// </summary>
        protected ModalDialogOption Options
        {
            get
            {
                var result = BaseOptions as ModalDialogOption;
                ArgumentNullException.ThrowIfNull(result);
                return result;
            }
        }

        protected Dictionary<string, object> MergeDialogAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                Options.DialogAdditionalAttributes,
                new([
                    new("disabled",DisabledValue!),
                    new("class",$"modal {Options.ActiveClass}")
                    ])
                );

        protected Dictionary<string, object> MergeHeaderAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                Options.HeaderAdditionalAttributes,
                new([
                    new("class","modal-card-head")
                    ])
                );
        protected Dictionary<string, object> MergeFooterAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                Options.FooterAdditionalAttributes,
                new([
                    new("class","modal-card-foot")
                    ])
                );

        protected Dictionary<string, object> MergeBodyAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                Options.BodyAdditionalAttributes,
                new([
                    new("class","modal-card-body")
                    ])
                );
        protected Dictionary<string, object> MergeContainerAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                Options.ContainerAdditionalAttributes,
                new([
                    new("class","modal-card")
                    ])
                );
        protected Dictionary<string, object> MergeTitleAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                Options.TitleAdditionalAttributes,
                new([
                    new("class","modal-card-title")
                    ])
                );
        protected Dictionary<string, object> MergeCloseButtonAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                Options.CloseButtonAdditionalAttributes,
                new([
                    new("class","delete"),
                    new("type","button"),
                    new("aria-label","close"),
                    new("onclick",EventCallback.Factory.Create(this,OnClose))
                    ])
                );
        protected async Task OnClose() => await InvokeAsync(() => Options.CloseDialog(DialogResult.Close));

        protected async Task OnPrimaryClick() => await InvokeAsync(() => Options.CloseDialog(DialogResult.Primary));

        protected async Task OnSecondaryClick() => await InvokeAsync(() => Options.CloseDialog(DialogResult.Secondary));

        protected async Task OnTertiaryClick() => await InvokeAsync(() => Options.CloseDialog(DialogResult.Tertiary));

    }
}
