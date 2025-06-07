using QualRazorLib.Presentation.Facades;
using QualRazorLib.Providers.Sources;
using QualRazorLibViewTest.Dtos;

namespace QualRazorLibViewTest.Facade
{
    public class CustomerFacade : ITableViewModel<TestCustomer>
    {
        public ITableDataProvider<TestCustomer> Data => throw new NotImplementedException();

        public bool IsLoading => throw new NotImplementedException();

        public bool HasError => throw new NotImplementedException();

        public string ErrorMessage => throw new NotImplementedException();

        public void ClearError()
        {
            throw new NotImplementedException();
        }

        public Task LoadAsync()
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
