namespace Clinic.Data.Contracts;

public interface IAppDbInitializer
{
    Task ConnectAsync();

    Task MigrateAsync();

    Task SeedAsync();
}
