using Microsoft.AspNetCore.Components;
using QualRazorLibViewTest.Dtos;
using QualRazorLibViewTest.Helpers;

namespace QualRazorLibViewTest.Pages.Customers
{
    [Route(AppRoutes.CUS_EDIT)]
    public partial class CustomerEdit:OwningComponentBase
    {
        public TestCustomer Model { get; set; } = new();

        protected IEnumerable<TestState> States { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            States = DummyDataHelper.GetTestStates();
        }
    }
}
