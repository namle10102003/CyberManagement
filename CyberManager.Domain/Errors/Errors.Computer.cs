using ErrorOr;

namespace CyberManager.Domain.Errors;

public static partial class Errors
{
    public static class Computer
    {
        public static Error SetErrorManually => Error.Validation(
            code: "Computer.SetErrorManually",
            description: "You can set computer error manually.");
    }
}