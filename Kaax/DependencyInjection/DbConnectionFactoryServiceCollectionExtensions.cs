using Kaax;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DbConnectionFactoryServiceCollectionExtensions
    {
        public static IDbConnectionBuilder AddDbConnection(this IServiceCollection services, string name)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.TryAddSingleton<DefaultDbConnectionProviderFactory>();
            services.TryAddSingleton<IDbConnectionProviderFactory>(serviceProvider => serviceProvider.GetRequiredService<DefaultDbConnectionProviderFactory>());

            services.TryAdd(ServiceDescriptor.Transient(typeof(ITypedDbClientFactory<>), typeof(DefaultTypedDbClientFactory<>)));

            return new DefaultDbConnectionBuilder(services, name);
        }
    }
}
