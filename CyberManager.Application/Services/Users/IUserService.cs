using CyberManager.Domain.Entities;
using ErrorOr;

namespace CyberManager.Application.Services.Users;

public interface IUserService
{
    Task<ErrorOr<UserResult>> Register(User user);
    Task<ErrorOr<UserResult>> Login(string userName, string password);
    Task<UserResult> GetById(int id);
    Task<ErrorOr<Updated>> ChangePassword(int id, string newPassword);
    Task<ErrorOr<Updated>> DepositCredit(int id, int cost);
    Task<ErrorOr<Updated>> UpdateCredit(int id, int credit);
}