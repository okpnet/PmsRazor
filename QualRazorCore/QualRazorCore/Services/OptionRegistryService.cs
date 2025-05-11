using Microsoft.Extensions.DependencyInjection;
using QualRazorCore.Options.Factories;
using QualRazorCore.Options.Registration;

namespace QualRazorCore.Services
{
    public static class OptionRegistryService
    {
        public static IServiceCollection AddOptionRegistry(this IServiceCollection services, Action<CompositeOptionFactory>? configureFactories = null)
        {
            services.AddScoped((provider) =>
            {
                var factory =new CompositeOptionFactory();
                factory.AddFactory(new DefaultOptionFactory());
                factory.AddFactory(new PropertyFieldOptionFactory());

                // 利用者が任意の Factory を追加できるようにする
                configureFactories?.Invoke(factory);
                return factory;
            });
            services.AddScoped<IOptionRegistry, FactoryBackedOptionRegistry>((provider) =>
            {
                var compositeFactory = provider.GetRequiredService<CompositeOptionFactory>();
                var factory=new FactoryBackedOptionRegistry(compositeFactory);
                return factory;
            });
            return services;
        }
    }
}
