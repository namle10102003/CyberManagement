using CyberManager.Application.Common.Interfaces.Persistences;
using CyberManager.Infrastructure.Persistance.DataAccess;
using CyberManager.Infrastructure.Persistance.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CyberManager.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastucture(this IServiceCollection services, string connectionString)
    {
        //Add infracstucture service
        services.AddPersistance(connectionString);
        return services;
    }

    private static IServiceCollection AddPersistance(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<IDataAccess>(_ => new DataAccess(connectionString));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ISoftwareRepository, SoftwareRepository>();
        services.AddScoped<IBillRepository, BillRepository>();
        services.AddScoped<IComputerRepository, ComputerRepository>();
        services.AddScoped<IComputerErrorRepository, ComputerErrorRepository>();

        return services;
    }
}