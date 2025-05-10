using Microsoft.Extensions.DependencyInjection;
using QualRazorCore.Options.Registry;

namespace QualRazorCore.Services
{
    public static class OptionRegistryService
    {
        public static IServiceCollection AddOptionRegistry(this IServiceCollection services)
        {
            services.AddScoped<IOptionRegistry, OptionRegistry>();
            //カスタムしたOptionFactoryを登録するときは、これを参考にして。
            //services.AddScoped<IOptionFactory, DefaultOptionFactory>();
            return services;
        }
    }
}
