using ErrorOr;

namespace CyberManager.Domain.Errors;

public static partial class Errors
{
    public static class Common
    {
        public static Error NullObject => Error.Conflict(
            code: "Common.NullObject",
            description: "The passed object is null");

        public static Error InstanceIsNotExists = Error.NotFound(
            code: "Common.InstaceIsNotExists",
            description: "The instance is not exists");
    }
}