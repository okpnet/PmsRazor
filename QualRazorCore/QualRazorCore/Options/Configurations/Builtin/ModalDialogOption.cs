using QualRazorCore.Controls;
using QualRazorCore.Core;
using QualRazorCore.Options.Core;
using System.ComponentModel;

namespace QualRazorCore.Options.Configurations.Builtin
{
    public class ModalDialogOption : NotifyCore, INotifyPropertyChanged, IOption
    {

        protected TaskCompletionSource<DialogResult>? _taskCompletionSource = default!;

        bool _isCloseButton;
        public bool IsCloseButton
        {
            get => _isCloseButton;
            set
            {
                if (_isCloseButton == value)
                {
                    return;
                }
                _isCloseButton = value;
                OnPropertyChanged(nameof(IsCloseButton));
            }
        }

        bool _isShow = false;
        protected bool IsShow
        {
            get => _isShow;
            set
            {
                if (_isShow == value)
                {
                    return;
                }
                _isShow = value;
                OnPropertyChanged(nameof(IsShow));
                OnPropertyChanged(nameof(ActiveClass));
            }
        }

        protected Dictionary<string, object> _dialogAdditionalAttributes = new();

        public Dictionary<string, object> DialogAdditionalAttributes
        {
            get => _dialogAdditionalAttributes;
            set
            {
                if (_dialogAdditionalAttributes == value)
                {
                    return;
                }
                _dialogAdditionalAttributes = value;
                OnPropertyChanged(nameof(DialogAdditionalAttributes));
            }
        }

        protected Dictionary<string, object> _headerAdditionalAttributes = new();

        public Dictionary<string, object> HeaderAdditionalAttributes
        {
            get => _headerAdditionalAttributes;
            set
            {
                if (_headerAdditionalAttributes == value)
                {
                    return;
                }
                _headerAdditionalAttributes = value;
                OnPropertyChanged(nameof(HeaderAdditionalAttributes));
            }
        }

        protected Dictionary<string, object> _bodyAdditionalAttributes = new();

        public Dictionary<string, object> BodyAdditionalAttributes
        {
            get => _bodyAdditionalAttributes;
            set
            {
                if (_bodyAdditionalAttributes == value)
                {
                    return;
                }
                _bodyAdditionalAttributes = value;
                OnPropertyChanged(nameof(BodyAdditionalAttributes));
            }
        }

        protected Dictionary<string, object> _footerAdditionalAttributes = new();

        public Dictionary<string, object> FooterAdditionalAttributes
        {
            get => _footerAdditionalAttributes;
            set
            {
                if (_footerAdditionalAttributes == value)
                {
                    return;
                }
                _footerAdditionalAttributes = value;
                OnPropertyChanged(nameof(FooterAdditionalAttributes));
            }
        }

        protected Dictionary<string, object> _containerAdditionalAttributes = new();

        public Dictionary<string, object> ContainerAdditionalAttributes
        {
            get => _containerAdditionalAttributes;
            set
            {
                if (_containerAdditionalAttributes == value)
                {
                    return;
                }
                _containerAdditionalAttributes = value;
                OnPropertyChanged(nameof(ContainerAdditionalAttributes));
            }
        }

        protected Dictionary<string, object> _titleAdditionalAttributes = new();

        public Dictionary<string, object> TitleAdditionalAttributes
        {
            get => _titleAdditionalAttributes;
            set
            {
                if (_titleAdditionalAttributes == value)
                {
                    return;
                }
                _titleAdditionalAttributes = value;
                OnPropertyChanged(nameof(TitleAdditionalAttributes));
            }
        }

        protected Dictionary<string, object> _closeButonAdditionalAttributes = new();

        public Dictionary<string, object> CloseButtonAdditionalAttributes
        {
            get => _closeButonAdditionalAttributes;
            set
            {
                if (_closeButonAdditionalAttributes == value)
                {
                    return;
                }
                _closeButonAdditionalAttributes = value;
                OnPropertyChanged(nameof(CloseButtonAdditionalAttributes));
            }
        }

        public string ActiveClass => _isShow ? ClassDefine.Modal.SHOW_ACTIVE : string.Empty;

        public Task<DialogResult> ShowDialog()
        {
            IsShow = true;
            _taskCompletionSource = new();
            return _taskCompletionSource.Task;
        }

        public void CloseDialog(DialogResult dialogResult)
        {
            IsShow = false;
            if (_taskCompletionSource is null)
            {
                return;
            }
            _taskCompletionSource.SetResult(dialogResult);
        }
    }
}
