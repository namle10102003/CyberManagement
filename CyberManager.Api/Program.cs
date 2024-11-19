using CyberManager.Api;
using CyberManager.Application;
using CyberManager.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    var connectionString = builder.Configuration.GetConnectionString("Default");

    if (connectionString is null)
        throw new Exception("The connection string can not be null");

    // Add services to the container.
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastucture(connectionString);
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}

