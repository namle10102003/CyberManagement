using CyberManager.Domain.Entities;

namespace CyberManager.Infrastructure.Tests.Persistance.Repositories.Constants;

public class SoftwareConstant
{
    public static Software CreateSoftware()
    {
        return new Software(0, "Test Case", "Test Case");
    }

    public static Software UpdateTestCase()
    {
        return new Software(1, "Update Test Case", Guid.NewGuid().ToString());
    }
}