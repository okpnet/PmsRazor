using Microsoft.AspNetCore.Components;
using QualRazorCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Toasts.Options
{
    public abstract class ToastOption : NotifyCore
    {
        public abstract string CssInformationClasses { get; }

        public abstract string CssGGIconClasses { get; }

        string _message = string.Empty;
        public string Message
        {
            get => _message;
            set
            {
                if (_message == value)
                {
                    return;
                }
                OnPropertyChanged(nameof(Message));
            }
        }

        public EventCallback CloseEvent { get; set; }


    }
}
