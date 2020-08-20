using Kaax.Sample.Storage;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Kaax.Sample
{
    class Program
    {
        static Task Main(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddDbConnection("sqlite")
                        .ConfigureDbConnection(c =>
                        {
                            c.ConnectionString = "Data Source=Databases/Books.db";
                            c.ProviderFactory = SqliteFactory.Instance;
                        })
                        .AddTypedClient<IBooksStorage, BooksSqlStorage>();

                    services.AddDbConnection("db")
                        .ConfigureDbConnection(c =>
                        {
                            c.ConnectionString = "Data Source=Databases/People.db";
                            c.ProviderFactory = SqliteFactory.Instance;
                        })
                        .AddTypedClient<IPeopleStorage, PeopleSqlStorage>();

                    services.AddHostedService<SampleService>();
                })
                .RunConsoleAsync();
        }
    }
}
