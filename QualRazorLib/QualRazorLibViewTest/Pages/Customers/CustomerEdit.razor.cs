using Microsoft.AspNetCore.Components;
using QualRazorLibViewTest.Dtos;
using QualRazorLibViewTest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLibViewTest.Pages.Customers
{
    [Route(AppRoutes.CUS_EDIT)]
    public partial class CustomerEdit:OwningComponentBase
    {
        public TestCustomer Model { get; set; } = new();
    }
}
