using QualRazorLib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalkLib.Pages.Results.ResultItems;

namespace QualRazorLib.Presentation.Facades
{
    public class TableViewModel<TModel> : ViewStateCore, IViewModel<ITalkPageResult<TModel>>, ITableViewModel where TModel : class
    {
        public ITalkPageResult<TModel> Data { get; protected set; } = default!;

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
