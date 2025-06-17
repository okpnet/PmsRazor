using Microsoft.AspNetCore.Components;
using QualRazorLibViewTest.Facade;
using QualRazorLibViewTest.Helpers;

namespace QualRazorLibViewTest.Pages.Customers
{
    [Route(AppRoutes.CUS_TABLE)]
    public partial class CustomerTables: OwningComponentBase
    {
        public CustomerFacade Facades { get; set; } = new();

    }
}
