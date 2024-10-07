using CyberManager.Domain.Entities;

namespace CyberManager.Infrastructure.Tests.Persistance.Repositories.Constants;

public class ComputerConstant
{
    public static Computer CreateComputer()
    {
        return new Computer(0, "Test Case", 1000, ComputerStatus.Online);
    }

    public static Computer UpdateTestCase()
    {
        return new Computer(1, Guid.NewGuid().ToString(), 1000, ComputerStatus.Online);
    }
}