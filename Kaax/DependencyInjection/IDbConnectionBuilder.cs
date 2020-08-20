namespace Microsoft.Extensions.DependencyInjection
{
    public interface IDbConnectionBuilder
    {
        string Name { get; }
        IServiceCollection Services { get; }
    }
}
