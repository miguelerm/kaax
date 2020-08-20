using Microsoft.Extensions.DependencyInjection;
using System;

namespace Kaax
{
    internal sealed class DefaultTypedDbClientFactory<TClient>: ITypedDbClientFactory<TClient>
    {
        private readonly IServiceProvider services;

        public DefaultTypedDbClientFactory(IServiceProvider services)
        {
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }

        public TClient CreateClient(IDbConnectionProvider dbConnectionProvider)
        {
            var factory = ActivatorUtilities.CreateFactory(typeof(TClient), new Type[] { typeof(IDbConnectionProvider) });
            return (TClient) factory(services, new object[] { dbConnectionProvider });
        }
    }
}
