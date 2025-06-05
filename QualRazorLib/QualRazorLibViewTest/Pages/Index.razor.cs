using Microsoft.AspNetCore.Components;
using QualRazorLibViewTest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLibViewTest.Pages
{
    [Route(AppRoutes.INDEX)]
    public partial class Index:OwningComponentBase
    {
        [Inject]
        public NavigationManager Navigation { get; set; }

        protected Task OnCustomerClick()
        {
            Navigation.NavigateTo(AppRoutes.CUS_EDIT);
            return Task.CompletedTask;
        }
        protected Task OnCustomerTableClick()
        {
            Navigation.NavigateTo(AppRoutes.CUS_TABLE);
            return Task.CompletedTask;
        }
    }
}
