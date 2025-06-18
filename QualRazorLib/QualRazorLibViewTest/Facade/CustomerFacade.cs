using QualRazorLib.Presentation.Facades;
using QualRazorLib.Providers.Sources;
using QualRazorLib.Views.QueryConditions;
using QualRazorLibViewTest.Dtos;
using QualRazorLibViewTest.Helpers;
using TalkLib.Pages.Request;

namespace QualRazorLibViewTest.Facade
{
    public class CustomerFacade : TableViewModelBase<TestCustomer>
    {
        protected ITalkPageRequest<TestCustomer> _request= new TalkPageRequest<TestCustomer>(1, 10);

        public override ITableDataProvider<TestCustomer> Data { get; protected set; }

        public CustomerFacade() : base(10)
        {
            QueryCondition = new DefaultViewQueryCondition<ITalkPageRequest<TestCustomer>>(
                (a) => { }
                );
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

         void Convert(IReadOnlyList<IValueFilter> valueFilters)
        {
            _request.ExpressionRoot.co
            foreach (var valueFilter in valueFilters.OfType<IValueFilter>())
            {
               
            }
        }
    }
}
