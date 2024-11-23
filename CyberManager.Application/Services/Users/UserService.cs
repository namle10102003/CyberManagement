using System.Text.RegularExpressions;
using CyberManager.Application.Common.Interfaces.Persistences;
using CyberManager.Domain.Entities;
using CyberManager.Domain.Errors;
using ErrorOr;

namespace CyberManager.Application.Services.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;
    private readonly IBillRepository _billRepo;

    public UserService(IUserRepository userRepo, IBillRepository billRepo)
    {
        _userRepo = userRepo;
        _billRepo = billRepo;
    }

    public async Task<ErrorOr<Updated>> ChangePassword(int id, string newPassword)
    {
        var user = await _userRepo.GetById(id);

        if (user is null)
        {
            return Errors.Common.InstanceIsNotExists;
        }

        user.Password = newPassword;
        await _userRepo.Update(user);

        return Result.Updated;
    }

    public async Task<ErrorOr<Updated>> DepositCredit(int id, int cost)
    {
        var user = await _userRepo.GetById(id);

        if (user is null)
        {
            return Errors.Common.InstanceIsNotExists;
        }

        user.Credit += cost;
        await _userRepo.Update(user);

        Bill bill =  Bill.CreateDepositBillForUser(user.UserName, cost);
        await _billRepo.Create(bill);

        return Result.Updated;
    }

    public async Task<UserResult> GetById(int id)
    {
        var user = await _userRepo.GetById(id);
        return new UserResult(user);
    }

    public async Task<ErrorOr<Updated>> UpdateCredit(int id, int credit)
    {
        var user = await _userRepo.GetById(id);

        if (user is null)
            return Errors.Common.InstanceIsNotExists;

        user.Credit = credit;
        await _userRepo.Update(user);

        return Result.Updated;
    }

    public async Task<ErrorOr<UserResult>> Login(string userName, string password)
    {
        var user = await _userRepo.GetByUserName(userName);

        if (user is null)
        {
            return Errors.User.WrongUserNameOrPassword;
        }

        if (password != user.Password)
        {
            return Errors.User.WrongUserNameOrPassword;
        }

        return new UserResult(user);
    }

    public async Task<ErrorOr<UserResult>> Register(User user)
    {
        if (!isValidUserName(user.UserName))
        {
            return Errors.User.InvalidUserName;
        }

        await _userRepo.Create(user);
        return new UserResult(user);
    }

    public bool isValidUserName(string userName)
    {
        if (string.IsNullOrEmpty(userName))
        {
            return false;
        }

        if (userName.Length < 5 || userName.Length > 20)
        {
            return false;
        }

        Regex validUsernamePattern = new Regex(@"^[a-zA-Z0-9_]+$");
        if (!validUsernamePattern.IsMatch(userName))
        {
            return false;
        }

        return true;
    }

}