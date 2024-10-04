using CyberManager.Infrastructure.Persistance.DataAccess;

namespace CyberManager.Infrastructure.Tests.Persistance.Repositories.Constants;

public class DataAccessConstant
{
    public static DataAccess CreateDataAccess()
    {
        return new DataAccess("Data Source=.\\CyberManagerDB.db");
    }
}