using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kaax.Sample.Storage
{
    interface IBooksStorage
    {
        Task<IEnumerable<Book>> GetAllAsync(CancellationToken cancellationToken);
    }
}
