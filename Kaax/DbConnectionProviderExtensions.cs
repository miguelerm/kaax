using System;
using System.Data;

namespace Kaax
{
    public static class DbConnectionProviderExtensions
    {
        public static IDbConnection OpenConnection(this IDbConnectionProvider dbConnectionProvider)
        {
            if (dbConnectionProvider is null)
            {
                throw new ArgumentNullException(nameof(dbConnectionProvider));
            }

            var connection = dbConnectionProvider.GetConnection();
            connection.Open();
            return connection;
        }
    }
}
