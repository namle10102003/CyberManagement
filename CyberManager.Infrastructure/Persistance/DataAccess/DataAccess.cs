using System.Data;
using Microsoft.Data.Sqlite;

namespace CyberManager.Infrastructure.Persistance.DataAccess;

public class DataAccess : IDataAccess
{
    private readonly string _connectionString;

    public DataAccess(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
        return new SqliteConnection(_connectionString);
    }
}