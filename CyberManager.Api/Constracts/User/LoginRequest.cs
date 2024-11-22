namespace CyberManager.Api.Constracts.User;

public record LoginRequest(
    string UserName,
    string Password
);