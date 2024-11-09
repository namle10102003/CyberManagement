using ErrorOr;

namespace CyberManager.Domain.Errors;

public static partial class Errors
{
    public static class User
    {
        //Register error
        public static Error DuplicateUserName => Error.Conflict(
            code: "User.DuplicateUserName",
            description: "The User name is dupllicate");

        public static Error InvalidUserName => Error.Conflict(
            code: "User.InvalidUserName",
            description: "The invalid User name");

        //Login
        public static Error WrongUserNameOrPassword => Error.Validation(
            code: "User.WrongUserNameOrPassword",
            description: "Wrong User name of passwork");

        //Other error
        public static Error UserNameNotFound => Error.NotFound(
            code: "User.UserNameNotFound",
            description: "The User name is not exists");
    }
}