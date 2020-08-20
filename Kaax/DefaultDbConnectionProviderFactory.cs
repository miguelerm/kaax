using Microsoft.Extensions.Options;
using System;

namespace Kaax
{
    internal sealed class DefaultDbConnectionProviderFactory : IDbConnectionProviderFactory
    {
        private readonly IOptionsMonitor<DbConnectionFactoryOptions> optionsMonitor;

        public DefaultDbConnectionProviderFactory(IOptionsMonitor<DbConnectionFactoryOptions> optionsMonitor)
        {
            this.optionsMonitor = optionsMonitor ?? throw new ArgumentNullException(nameof(optionsMonitor));
        }

        public IDbConnectionProvider CreateProvider(string name)
        {
            var options = optionsMonitor.Get(name);
            var provider = new DefaultDbConnectionProvider(options.ProviderFactory, options.ConnectionString);
            return provider;
        }
    }
}
