using CyberManager.Api;
using CyberManager.Application;
using CyberManager.Infrastructure;
using CyberManager.Infrastructure.Persistance.Database;

var builder = WebApplication.CreateBuilder(args);
{
    var connectionString = builder.Configuration.GetConnectionString("Default");

    if (connectionString is null)
        throw new Exception("The connection string can not be null");

    DbInitializor.Initialize(connectionString);

    // Add services to the container.
    builder.Services
        .AddInfrastucture(connectionString)
        .AddApplication()
        .AddPresentation();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

