using Kaax.Sample.Storage;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kaax.Sample
{
    internal class SampleService : IHostedService
    {
        private readonly IPeopleStorage people;
        private readonly IBooksStorage books;
        private readonly ILogger<SampleService> logger;

        public SampleService(IPeopleStorage people, IBooksStorage books, ILogger<SampleService> logger = null)
        {
            this.people = people ?? throw new ArgumentNullException(nameof(people));
            this.books = books ?? throw new ArgumentNullException(nameof(books));
            this.logger = logger ?? NullLogger<SampleService>.Instance;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogDebug("Getting test data");

            var peopeTask = people.GetAllAsync(cancellationToken);
            var booksTask = books.GetAllAsync(cancellationToken);

            var peopleResult = await peopeTask.ConfigureAwait(false);
            var booksResult = await booksTask.ConfigureAwait(false);

            var peopleOutput = new StringBuilder();

            peopleOutput.AppendLine($"A total of {peopleResult.Count()} people found:");
            foreach (var person in peopleResult)
            {
                peopleOutput.AppendLine($"  {person.Id}) {person.Name}");
            }


            var booksOutput = new StringBuilder();

            booksOutput.AppendLine($"A total of {booksResult.Count()} books found:");
            foreach (var book in booksResult)
            {
                booksOutput.AppendLine($"  {book.Id}) {book.Title}");
            }

            logger.LogInformation(peopleOutput.ToString());
            logger.LogInformation(booksOutput.ToString());
            
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
