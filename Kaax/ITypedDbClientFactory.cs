namespace Kaax
{
    public interface ITypedDbClientFactory<TClient>
    {
        TClient CreateClient(IDbConnectionProvider dbConnectionProvider);
    }
}
