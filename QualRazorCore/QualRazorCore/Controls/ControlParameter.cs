using QualRazorCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls
{
    public abstract class ControlParameter:NotifyCore
    {
        protected bool _isEnable=true;
        public bool IsEnable
        {
            get => _isEnable;
            set
            {
                if(_isEnable == value) return;
                _isEnable = value;
                OnPropertyChanged(nameof(IsEnable));
            }
        }

        protected bool _isHidden=false;
        public bool IsHidden
        {
            get => _isHidden;
            set
            {
                if(_isHidden == value) return;
                _isHidden = value;
                OnPropertyChanged(nameof(IsHidden));
            }
        }

        public string? HiddenAttribute => _isHidden ? null : "hidden";
    }
}
