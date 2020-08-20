using System;
using System.Data;
using System.Data.Common;

namespace Kaax
{
    internal sealed class DefaultDbConnectionProvider : IDbConnectionProvider
    {
        private readonly DbProviderFactory dbProviderFactory;
        private readonly string connectionString;

        public DefaultDbConnectionProvider(DbProviderFactory dbProviderFactory, string connectionString)
        {
            this.dbProviderFactory = dbProviderFactory ?? throw new ArgumentNullException(nameof(dbProviderFactory));
            this.connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public IDbConnection GetConnection()
        {
            var connection = dbProviderFactory.CreateConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }
    }
}
