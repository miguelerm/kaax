using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kaax.Sample.Storage
{
    interface IPeopleStorage
    {
        Task<IEnumerable<Person>> GetAllAsync(CancellationToken cancellationToken);
    }
}
