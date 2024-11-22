namespace CyberManager.Api.Constracts.User;

public record ChangePasswordRequest(
    int Id,
    string Password
);