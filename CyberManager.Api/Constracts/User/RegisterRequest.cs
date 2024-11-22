namespace CyberManager.Api.Constracts.User;

public record RegisterRequest(
    string UserName,
    string Password,
    int Credit
);