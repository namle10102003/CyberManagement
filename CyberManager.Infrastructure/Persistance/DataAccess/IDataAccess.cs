using System.Data;
using Microsoft.Data.Sqlite;

namespace CyberManager.Infrastructure.Persistance.DataAccess;

public interface IDataAccess
{
    IDbConnection CreateConnection();
}