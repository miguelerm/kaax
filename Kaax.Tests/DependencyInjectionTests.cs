using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Kaax.Tests
{
    public partial class DependencyInjectionTests
    {
        [Fact]
        public void Test1()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbConnection("A")
                .ConfigureDbConnection(c =>
                {
                    c.ConnectionString = "Server=Test;Database=A";
                    c.ProviderFactory = new TestDbProviderFactory();
                })
                .AddTypedClient<ITestClientA, TestClient>()
                .AddTypedClient<ITestClientB, TestClient>();

            serviceCollection.AddDbConnection("B")
                .ConfigureDbConnection(c =>
                {
                    c.ConnectionString = "Server=Test;Database=B"; ;
                    c.ProviderFactory = new TestDbProviderFactory();
                })
                .AddTypedClient<ITestClientC, TestClient>()
                .AddTypedClient<ITestClientD, TestClient>();

            var services = serviceCollection.BuildServiceProvider();

            var clientA = services.GetRequiredService<ITestClientA>();
            var clientB = services.GetRequiredService<ITestClientB>();
            var clientC = services.GetRequiredService<ITestClientC>();
            var clientD = services.GetRequiredService<ITestClientD>();

            Assert.Equal("Server=Test;Database=A", clientA.GetConnectionString());
            Assert.Equal("Server=Test;Database=A", clientB.GetConnectionString());
            Assert.Equal("Server=Test;Database=B", clientC.GetConnectionString());
            Assert.Equal("Server=Test;Database=B", clientD.GetConnectionString());

        }

        private interface ITestClient
        {
            string GetConnectionString();
        }

        private interface ITestClientA : ITestClient { }
        private interface ITestClientB : ITestClient { }
        private interface ITestClientC : ITestClient { }
        private interface ITestClientD : ITestClient { }

        private class TestClient : ITestClientA, ITestClientB, ITestClientC, ITestClientD
        {
            protected readonly IDbConnectionProvider dbConnectionProvider;

            public TestClient(IDbConnectionProvider dbConnectionProvider)
            {
                this.dbConnectionProvider = dbConnectionProvider ?? throw new System.ArgumentNullException(nameof(dbConnectionProvider));
            }

            public virtual string GetConnectionString()
            {
                return dbConnectionProvider.GetConnection().ConnectionString;
            }
        }

    }
}
