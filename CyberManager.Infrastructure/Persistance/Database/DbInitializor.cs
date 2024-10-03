using System.Reflection;
using DbUp;

namespace CyberManager.Infrastructure.Persistance.Database;

public class DbInitializor
{
    public static void Initialize(string connectionString) 
    {
        var updater = DeployChanges.To
            .SQLiteDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .WithTransaction()
            .LogToConsole()
            .Build();

        var result = updater.PerformUpgrade();

        if (!result.Successful)
        {
            throw new InvalidOperationException("Failed Migrading");
        }
    }
}