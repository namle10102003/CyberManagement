using CyberManager.Application.Services;
using CyberManager.Application.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace CyberManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //Add application service
        services.AddServices();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        //Add services
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}