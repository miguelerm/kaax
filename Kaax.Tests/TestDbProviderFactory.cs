using System.Data.Common;

namespace Kaax.Tests
{
    public partial class DependencyInjectionTests
    {
        private class TestDbProviderFactory: DbProviderFactory
        {
            public override DbConnection CreateConnection()
            {
                return new TestDbConnection();
            }
        }
    }
}
