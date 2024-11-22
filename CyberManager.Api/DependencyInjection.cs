using CyberManager.Api.Mapping;

namespace CyberManager.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddMapping();

        return services;
    }
}