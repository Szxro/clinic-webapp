using Clinic.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Clinic.Data.Persistence;

public class AppDbInitializer : IAppDbInitializer
{
    private readonly AppDbContext _appDbContext;
    private readonly ILogger<AppDbInitializer> _logger;
    private readonly IVacationPeriodStatus _vacationPeriodStatus;

    public AppDbInitializer(AppDbContext appDbContext,
                            ILogger<AppDbInitializer> logger,
                            IVacationPeriodStatus vacationPeriodStatus)
    {
        _appDbContext = appDbContext;
        _logger = logger;
        _vacationPeriodStatus = vacationPeriodStatus;
    }
    public async Task ConnectAsync()
    {
        try
        {
            await _appDbContext.Database.CanConnectAsync();
        
        } catch(Exception ex)
        {
            _logger.LogError("An error occured trying to connect to the database with the provider name {databaseProviderName} : {message}", _appDbContext.Database.ProviderName,ex.Message);

            throw;
        }
    }

    public async Task MigrateAsync()
    {
        try 
        {
            await _appDbContext.Database.MigrateAsync();

        }catch(Exception ex)
        {
            _logger.LogError("An error occured trying to do migration to the database with the provider name {databaseProviderName} : {message}",_appDbContext.Database.ProviderName,ex.Message);
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedVacationPeriodStatusAsync();

        } catch(Exception ex)
        {
            _logger.LogError("An error occurred trying to seed the database with the error message : {message}",ex.Message);

            throw;
        }
    }

    private async Task TrySeedVacationPeriodStatusAsync()
    {
        if (!_appDbContext.VacationPeriodStatus.Any())
        {
            await _vacationPeriodStatus.AddDefaultVacationPeriodStatus();
        }
    }
}
