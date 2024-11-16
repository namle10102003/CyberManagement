using CyberManager.Application.Services;
using CyberManager.Application.Services.Bills;
using CyberManager.Application.Services.ComputerErrors;
using CyberManager.Application.Services.Computers;
using CyberManager.Application.Services.Softwares;
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
        services.AddScoped<IBillService, BillService>();
        services.AddScoped<ISoftwareService, SoftwareService>();
        services.AddScoped<IComputerService, ComputerService>();
        services.AddScoped<IComputerErrorService, ComputerErrorService>();

        return services;
    }
}