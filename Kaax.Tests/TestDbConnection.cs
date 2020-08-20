using System.Data;
using System.Data.Common;

namespace Kaax.Tests
{
    public partial class DependencyInjectionTests
    {
        private class TestDbConnection : DbConnection
        {
            public override string ConnectionString { get; set; }

            public override string Database => throw new System.NotImplementedException();

            public override string DataSource => throw new System.NotImplementedException();

            public override string ServerVersion => throw new System.NotImplementedException();

            public override ConnectionState State => throw new System.NotImplementedException();

            public override void ChangeDatabase(string databaseName)
            {
                throw new System.NotImplementedException();
            }

            public override void Close()
            {
                throw new System.NotImplementedException();
            }

            public override void Open()
            {
                throw new System.NotImplementedException();
            }

            protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
            {
                throw new System.NotImplementedException();
            }

            protected override DbCommand CreateDbCommand()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
