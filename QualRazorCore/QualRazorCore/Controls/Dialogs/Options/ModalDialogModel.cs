using QualRazorCore.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Dialogs.Options
{
    public class ModalDialogModel: NotifyCore,INotifyPropertyChanged
    {
        bool _isShow = false;
        public bool IsShow
        {
            get => _isShow;
            set
            {
                if (_isShow == value)
                {
                    return;
                }
                _isShow = value;
                OnPropertyChanged(nameof(ActiveClass));
                OnPropertyChanged(nameof(IsShow));
            }
        }

        public string ActiveClass => IsShow ? ClassDefine.Modal.SHOW_ACTIVE : string.Empty;
    }
}
