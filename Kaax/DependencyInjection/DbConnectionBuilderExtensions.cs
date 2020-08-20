using Kaax;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DbConnectionBuilderExtensions
    {
        public static IDbConnectionBuilder ConfigureDbConnection(this IDbConnectionBuilder builder, Action<DbConnectionFactoryOptions> configureClient)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (configureClient is null)
            {
                throw new ArgumentNullException(nameof(configureClient));
            }

            builder.Services.Configure(builder.Name, configureClient);

            return builder;
        }

        public static IDbConnectionBuilder AddTypedClient<TClient, TImplementation>(this IDbConnectionBuilder builder)
            where TClient : class
            where TImplementation : class, TClient
        {
            builder.Services.AddTransient<TClient>(s =>
            {
                var dbConnectionProviderFactory = s.GetRequiredService<IDbConnectionProviderFactory>();
                var dbConnectionProvider = dbConnectionProviderFactory.CreateProvider(builder.Name);

                var typedClientFactory = s.GetRequiredService<ITypedDbClientFactory<TImplementation>>();
                return typedClientFactory.CreateClient(dbConnectionProvider);
            });
            return builder;
        }
    }
}
