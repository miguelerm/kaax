namespace Kaax
{
    public interface IDbConnectionProviderFactory
    {
        IDbConnectionProvider CreateProvider(string name);
    }
}
