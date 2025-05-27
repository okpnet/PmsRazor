using QualRazorLib.Models.Core;
using QualRazorLib.Presentation.Facades;
using QualRazorLib.Providers.Sources;

namespace QualRazorLib.Models.Tables
{
    public class TableViewModel<TModel> : ViewStateCore, IViewModel<ITableDataProvider<TModel>>, ITableViewModel where TModel : class
    {
        public ITableDataProvider<TModel> Data { get; protected set; } = default!;

        protected int _maxNumberOfPage;
        public int MaxNumberOfPage
        {
            get => _maxNumberOfPage;
            set
            {
                if (_maxNumberOfPage == value)
                {
                    return;
                }
                _maxNumberOfPage = value;
                OnPropertyChanged(nameof(MaxNumberOfPage));
            }
        }

        public void ChangeSortOrder()
        {
            throw new NotImplementedException();
        }

        public override void ClearError()
        {
            throw new NotImplementedException();
        }

        public bool InvokeAction(string key)
        {
            throw new NotImplementedException();
        }

        public Task LoadAsync()
        {
            throw new NotImplementedException();
        }

        public void RegisterAction(string key, Action action)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public override void SetError(string message)
        {
            throw new NotImplementedException();
        }

        public override void SetLoading(bool isLoading)
        {
            throw new NotImplementedException();
        }

        public Task SubmitAsync()
        {
            throw new NotImplementedException();
        }
    }
}
