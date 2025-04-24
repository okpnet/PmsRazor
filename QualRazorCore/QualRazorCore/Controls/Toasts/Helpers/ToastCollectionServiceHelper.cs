using BlazorToaster.Core;
using Microsoft.Extensions.DependencyInjection;
using QualRazorCore.Controls.Toasts.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Toasts.Helpers
{
    public static class ToastCollectionServiceHelper
    {
        public static IServiceCollection AddToastCollection(this IServiceCollection services)
        {
            services.AddSingleton<IToastModelCollsection<ToastOption>, ToastCollecion<ToastOption>>(provider =>
            {
                var confing = new ToastConfigure() { MaxToast = 3, Duration = 3000 };
                return new ToastCollecion<ToastOption>(confing);
            });
            return services;
        }
    }
}
