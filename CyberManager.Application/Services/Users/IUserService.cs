using CyberManager.Domain.Entities;
using ErrorOr;

namespace CyberManager.Application.Services.Users;

public interface IUserService
{
    Task<ErrorOr<UserResult>> Register(User user);
    Task<ErrorOr<UserResult>> Login(string userName, string password);
    Task<ErrorOr<UserResult>> ChangePassword(string userName, string newPassword);
    Task<ErrorOr<UserResult>> DepositCredit(string userName, int cost);
}