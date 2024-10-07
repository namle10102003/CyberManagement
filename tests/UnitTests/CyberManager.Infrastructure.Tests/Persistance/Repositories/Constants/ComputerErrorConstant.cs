using CyberManager.Domain.Entities;

namespace CyberManager.Infrastructure.Tests.Persistance.Repositories.Constants;

public class ComputerErrorConstant
{
    public static ComputerError CreateComputerError()
    {
        return new ComputerError(0, 1, Devices.CPU, "Test Case", false);
    }

    public static ComputerError UpdateTestCase()
    {
        return new ComputerError(1, 1, Devices.CPU, Guid.NewGuid().ToString(), false);
    }
}