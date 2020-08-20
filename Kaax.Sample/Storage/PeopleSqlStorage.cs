using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kaax.Sample.Storage
{
    class PeopleSqlStorage : IPeopleStorage
    {
        private readonly IDbConnectionProvider db;

        public PeopleSqlStorage(IDbConnectionProvider db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public Task<IEnumerable<Person>> GetAllAsync(CancellationToken cancellationToken)
        {
            return db.QueryAsync<Person>("SELECT * FROM People", cancellationToken: cancellationToken);
        }
    }
}
