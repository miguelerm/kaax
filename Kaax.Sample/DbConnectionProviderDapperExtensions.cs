using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Kaax.Sample
{
    static class DbConnectionProviderDapperExtensions
    {
        public static async Task<IEnumerable<T>> QueryAsync<T>(this IDbConnectionProvider dbConnectionProvider, string commandText, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default)
        {
            using var connection = dbConnectionProvider.OpenConnection();
            var result = await connection.QueryAsync<T>(new CommandDefinition(commandText, param, transaction, commandTimeout, commandType, cancellationToken: cancellationToken)).ConfigureAwait(false);
            return result;
        }
    }
}
