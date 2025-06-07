using QualRazorLib.Models.Tables;
using QualRazorLib.Providers.Sources;

namespace QualRazorLib.Presentation.Facades
{
    public abstract class TableViewModelBase<T> : ITableViewModel<T>, ITableViewModel, ITableViewParameter where T : class
    {
        public ITableDataProvider<T> Data => throw new NotImplementedException();

        public bool IsLoading { get; protected set; } = false;

        public bool HasError { get; protected set; } = false;

        public string ErrorMessage { get; protected set; } = string.Empty;

        public int MaxNumberOfPage => throw new NotImplementedException();

        public virtual void ClearError()
        {
            HasError = false;
            ErrorMessage = string.Empty;
        }

        public abstract Task LoadAsync();

        public virtual void Reset()
        {
            ClearError();
        }

        public virtual void SetError(string message)
        {
            HasError = true;
            ErrorMessage = message;
        }

        public virtual void SetLoading(bool isLoading)
        {
            IsLoading = isLoading;
        }

        public abstract Task SubmitAsync();

    }
}
