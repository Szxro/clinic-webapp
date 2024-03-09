using Clinic.Data.Options;
using Clinic.Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using FluentValidation;
using System.Reflection;
using Clinic.Data.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Clinic.Data.Contracts;
using Clinic.Data.Repositories;
using Clinic.Data.Common;
using System.Runtime.CompilerServices;
using Clinic.Data.Persistence.Interceptors;

namespace Clinic.Data;

public static class DataServiceRegistration
{
    public static IServiceCollection AddDataLayer(this IServiceCollection services,IConfiguration configuration,IWebHostEnvironment hostEnvironment)
    {
        services.AddOptions<DatabaseOptions>()
                .Configure(settings => configuration.GetSection(DatabaseOptions.sectionName)
                .Bind(settings));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddSingleton<IValidateOptions<DatabaseOptions>, DatabaseOptionsServiceValidator>();

        services.AddSingleton<AuditableEntititesInterceptor>();

        services.AddDbContext<AppDbContext>((serviceProvider, options) => 
        {
            DatabaseOptions databaseOptions = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;

            options.UseSqlServer(databaseOptions.ConnectionString,sqlServerOptionsAction =>
            {
                sqlServerOptionsAction.CommandTimeout(databaseOptions.CommandTimeout);

                sqlServerOptionsAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
            })
            .AddInterceptors(serviceProvider.GetRequiredService<AuditableEntititesInterceptor>());

            if (hostEnvironment.IsDevelopment())
            {
                options.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
                options.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
            }
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IVacationPeriodStatus, VacationPeriodStatusRepository>();
        services.AddTransient<IAppDbInitializer, AppDbInitializer>();
        services.AddTransient<IDateService, DateService>();

        return services;
    }

    public static async Task InitializeDatabaseAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        IAppDbInitializer initializer = scope.ServiceProvider.GetRequiredService<IAppDbInitializer>();

        await initializer.ConnectAsync();

        await initializer.MigrateAsync();

        await initializer.SeedAsync();
    }
}
