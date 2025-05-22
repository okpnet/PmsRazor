using QualRazorLib.Intterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalkLib.Pages.Results.ResultItems;

namespace QualRazorLib.Controls.Tables
{
    public class TableViewModel<TModel> : IViewModel<ITalkPageResult<TModel>>, ITableViewModel<TModel> where TModel : class
    {
        public ITalkPageResult<TModel> Data { get; protected set; } = default!;

        public bool IsLoading => throw new NotImplementedException();

        public bool HasError => throw new NotImplementedException();

        public string ErrorMessage => throw new NotImplementedException();

        TModel IDataHolder<TModel>.Data => throw new NotImplementedException();

        public void ChangeSortOrder()
        {
            throw new NotImplementedException();
        }

        public void ClearError()
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

        public void SetError(string message)
        {
            throw new NotImplementedException();
        }

        public void SetLoading(bool isLoading)
        {
            throw new NotImplementedException();
        }

        public Task SubmitAsync()
        {
            throw new NotImplementedException();
        }
    }
}
