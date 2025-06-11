using Microsoft.AspNetCore.Components;
using QualRazorLibViewTest.Facade;
using QualRazorLibViewTest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLibViewTest.Pages.Customers
{
    [Route(AppRoutes.CUS_TABLE)]
    public partial class CustomerTables: OwningComponentBase
    {
        public CustomerFacade Facade { get; set; } = new();

    }
}
