using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Core
{
    public abstract class RazorCore: ComponentBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        protected bool _isDisabled;
        public bool IsDisable 
        {
            get => _isDisabled;
            set 
            {
                if (_isDisabled == value)
                {
                    return;
                }
                _isDisabled = value;
                OnPropertyChanged(nameof(IsDisable));
                OnPropertyChanged(nameof(DisabledValue));
            }
        }

        public string? DisabledValue => _isDisabled ? "disabled" : null;

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object>? AdditionalAttributes { get; set; }

        [Parameter]
        public RenderFragment? LoadingContent { get; set; }
    }
}
