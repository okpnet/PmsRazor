using QualRazorLib.Presentation.Facades;
using QualRazorLib.Providers.Sources;
using QualRazorLibViewTest.Dtos;
using QualRazorLibViewTest.Helpers;

namespace QualRazorLibViewTest.Facade
{
    public class CustomerFacade : TableViewModelBase<TestCustomer>
    {
        public override ITableDataProvider<TestCustomer> Data => throw new NotImplementedException();

        public CustomerFacade(int maxNumberOfPage) : base(maxNumberOfPage)
        {
        }

        

        public override Task LoadAsync()
        {
            var array = DummyDataHelper.GetTestCustomers().AsEnumerable();
            var numOfRecords = array.Count();
            var pagenum = 100 > numOfRecords ? 1 : Math.Ceiling(((decimal)numOfRecords)/100);
            var result=new TableDataProvider<TestCustomer>()
            {
                NumberOfRecords= numOfRecords,
                PageNumber = this.QueryCondition.PageIndex,
            };
            var page=this.QueryCondition.PageIndex == 0 ? 1 : QueryCondition.PageIndex;
            
            DummyDataHelper.GetTestCustomers().Skip(0).Take(100);
        }

        public override Task SubmitAsync()
        {
            throw new NotImplementedException();
        }
    }
}
