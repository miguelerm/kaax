namespace Microsoft.Extensions.DependencyInjection
{
    internal sealed class DefaultDbConnectionBuilder: IDbConnectionBuilder
    {
        public DefaultDbConnectionBuilder(IServiceCollection services, string name)
        {
            Services = services;
            Name = name;
        }

        public IServiceCollection Services { get; }
        public string Name { get; }
    }
}
