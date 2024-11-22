namespace CyberManager.Api.Constracts.User;

public record UserResponse(
    int Id,
    string UserName,
    int Credit
);