using CyberManager.Infrastructure.Persistance.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace CyberManager.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastucture(this IServiceCollection services, string connectionString)
    {
        //Add infracstucture service
        services.AddSingleton<IDataAccess>(_ => new DataAccess(connectionString));
        return services;
    }
}