using QualRazorLib.Presentation.Facades;
using QualRazorLib.Providers.Sources;
using QualRazorLibViewTest.Dtos;
using QualRazorLibViewTest.Helpers;

namespace QualRazorLibViewTest.Facade
{
    public class CustomerFacade : TableViewModelBase<TestCustomer>
    {
        public override ITableDataProvider<TestCustomer> Data => throw new NotImplementedException();

        public CustomerFacade() : base(10)
        {
        }

        public override async Task LoadAsync()
        {
            await Task.Run(() =>
            {
                IsLoading = true;
                var array = DummyDataHelper.GetTestCustomers().AsEnumerable();
                var numOfRecords = array.Count();
                var pagenum = 100 > numOfRecords ? 1 : Math.Ceiling(((decimal)numOfRecords) / 100);
                var values = pagenum == 1 ? DummyDataHelper.GetTestCustomers() : DummyDataHelper.GetTestCustomers().Skip((QueryCondition.PageIndex - 1) * 100);
                values.Take(100);
                var result = new TableDataProvider<TestCustomer>()
                {
                    NumberOfRecords = numOfRecords,
                    PageNumber = QueryCondition.PageIndex,
                    NumberOfPage = (int)pagenum,
                    NumberOfMatchedRecords = numOfRecords, // ここでは全件一致とする
                    Sources = [.. values]
                };
                IsLoading = false;
            });

        }

        public override Task SubmitAsync()
        {
            throw new NotImplementedException();
        }
    }
}
