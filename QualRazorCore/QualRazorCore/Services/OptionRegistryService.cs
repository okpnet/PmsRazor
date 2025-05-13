using Microsoft.Extensions.DependencyInjection;
using QualRazorCore.Options.Configurations.Core;
using QualRazorCore.Options.ViewOptions.Core;

namespace QualRazorCore.Services
{
    public static class OptionRegistryService
    {
        public static IServiceCollection AddOptionRegistry(this IServiceCollection services)
        {
            services.AddScoped<IViewOptionRegistry, ViewOptionRegistry>();
            services.AddScoped<IConfigOptionRegistry, ConfigOptionRegistry>();
            return services;
        }
    }
}
