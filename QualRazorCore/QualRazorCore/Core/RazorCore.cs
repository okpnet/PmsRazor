using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using QualRazorCore.Extenssions;
using QualRazorCore.Observers;
using System.ComponentModel;

namespace QualRazorCore.Core
{
    public abstract class RazorCore: OwningComponentBase, INotifyPropertyChanged,IDisposable
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected readonly DisposableCollection disposables = new();


        protected virtual void OnPropertyChanged(string propertyName)
        {
            try
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"{ex.Message}===>{propertyName}");
            }
        }



        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object>? AdditionalAttributes { get; set; }

        [Parameter]
        public RenderFragment? LoadingContent { get; set; }

        protected bool _isDisabled=false;
        public string? DisabledValue { get; protected set; } = null;
        [Parameter]
        public bool IsDisabled { get; set; }

        protected bool _isHidden = true;
        public string? HiddenValue { get; protected set; } = null;
        [Parameter]
        public bool IsHidden { get; set; } = false;


        protected Dictionary<string, object> MeargeAttributeBase=> HtmlAttributeHelper.MergeAttributes(
            AdditionalAttributes,
            new()
            {
                ["disabled"] = DisabledValue!,
                ["class"]= HiddenValue!,
            });


        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (_isDisabled != IsDisabled)
            {//Disabledパラメーター
                _isDisabled = IsDisabled;
                DisabledValue=_isDisabled ? "disabled" : null;
            }
            if (_isHidden != IsHidden)
            {//Hiddenパラメーター
                _isHidden = IsHidden;
                HiddenValue = _isHidden ? "is-hidden" : "";
            }
        }

        protected virtual Task OnLeftMouseClick(MouseKeyArg e)
        {
            return Task.CompletedTask;
        }

        protected virtual Task OnRightMouseClick(MouseKeyArg e)
        {
            return Task.CompletedTask;
        }

        protected virtual Task OnMouseClick(MouseEventArgs e)
        {
            var arg = new MouseKeyArg(e.ShiftKey, e.AltKey);
            switch (e.Button)
            {
                case 0:
                    return OnLeftMouseClick(arg);
                case 1:
                    return OnRightMouseClick(arg);
            }
            return Task.CompletedTask;
        }


        protected override void Dispose(bool disposing)
        {
            disposables.Clear();
            base.Dispose(disposing); 
        }
    }
}
