using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kaax.Sample.Storage
{
    class BooksSqlStorage : IBooksStorage
    {
        private readonly IDbConnectionProvider db;

        public BooksSqlStorage(IDbConnectionProvider db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public Task<IEnumerable<Book>> GetAllAsync(CancellationToken cancellationToken)
        {
            return db.QueryAsync<Book>("SELECT * FROM Books", cancellationToken: cancellationToken);
        }
    }
}
