using CyberManager.Application.Common.Interfaces.Services;

namespace CyberManager.Application.Services;

public class Greeting : IGreeting
{
    public string Greet()
    {
        return "Hello";
    }
}