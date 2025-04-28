using QualRazorCore.Core;
using System.ComponentModel;

namespace QualRazorCore.Controls.Dialogs.Options
{
    public class ModalDialogOption: NotifyCore,INotifyPropertyChanged
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
            if(_taskCompletionSource is null)
            {
                return;
            }
            _taskCompletionSource.SetResult(dialogResult);
        }
    }
}
