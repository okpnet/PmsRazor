using QualRazorLib.Core;
using QualRazorLib.Views.States;
using System.ComponentModel;

namespace QualRazorLib.Models.Core
{
    public abstract class ViewStateCore : NotifyCore, INotifyPropertyChanged, IViewState
    {
        protected bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                if (_isLoading == value)
                {
                    return;
                }
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }
        protected bool _hasError;
        public bool HasError
        {
            get => _hasError;
            set
            {
                if (_hasError == value)
                {
                    return;
                }
                _hasError = value;
                OnPropertyChanged(nameof(HasError));
            }
        }

        protected string _errorMessage = string.Empty;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (_errorMessage == value)
                {
                    return;
                }
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public abstract void SetLoading(bool isLoading);

        public abstract void SetError(string message);

        public abstract void ClearError();
    }
}
