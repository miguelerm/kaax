# K’aax

A simple .net core database connection provider.

## Usage Example

```cs
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbConnection("DatabaseA")
        .ConfigureDbConnection(c =>
        {
            c.ConnectionString = "Data Source=sqlite-a.db";
            c.ProviderFactory = Microsoft.Data.Sqlite.SqliteFactory.Instance;
        })
        .AddTypedClient<ICatsStorage, CatsSqlStorage>()
        .AddTypedClient<ISquirrelsStorage, SquirrelsSqlStorage>();

    services.AddDbConnection("DatabaseB")
        .ConfigureDbConnection(c =>
        {
            c.ConnectionString = "Server=127.0.0.1;Database=SqlB;User Id=sa;Password=secret;";
            c.ProviderFactory = DbProviderFactories.GetFactory("Microsoft.Data.SqlClient");
        })
        .AddTypedClient<IDogsStorage, DogsSqlStorage>();
        .AddTypedClient<IBearsStorage, BearsSqlStorage>();
}
```

In the previous example all storage classes will receive an instance of
`IDbConnectionProvider` which allows to create database connections.
For Example:

```cs
class DogsSqlStorage
{
    public DogsSqlStorage(IDbConnectionProvider db)
    {
        this.db = db;
    }

    public int Count()
    {
        using var connection = dbConnectionProvider.OpenConnection();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT COUNT(*) FROM Canines";
        return (int) command.ExecuteScalar();
    }
}
```

> To see a complete example you can check the console application on
> [Kaax.Sample](./Kaax.Sample) folder.
