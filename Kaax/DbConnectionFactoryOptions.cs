using System.Data.Common;

namespace Kaax
{
    public class DbConnectionFactoryOptions
    {
        public string ConnectionString { get; set; }
        public DbProviderFactory ProviderFactory { get; set; }
    }
}
