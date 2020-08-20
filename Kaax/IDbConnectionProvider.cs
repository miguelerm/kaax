using System.Data;

namespace Kaax
{
    public interface IDbConnectionProvider
    {
        IDbConnection GetConnection();
    }
}
