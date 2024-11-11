using CyberManager.Application.Common.Interfaces.Persistences;
using CyberManager.Domain.Entities;
using CyberManager.Infrastructure.Persistance.DataAccess;
using CyberManager.Infrastructure.Persistance.Repositories;
using CyberManager.Infrastructure.Tests.Persistance.Repositories.Constants;
using ErrorOr;

namespace CyberManager.Infrastructure.Tests.Persistance.Repositories;

public class UserRepositoryTest
{
    private readonly IDataAccess _dataAccess;
    private readonly IUserRepository _userRepository;

    public UserRepositoryTest()
    {
        _dataAccess = DataAccessConstant.CreateDataAccess();
        _userRepository = new UserRepository(_dataAccess);
    }

    [Fact]
    public async void Should_Create_User()
    {
        User user = UserConstant.CreateUser();

        await _userRepository.Create(user);

        var listUser = await _userRepository.Get(user.UserName);
        var createdUser = listUser.First();

        Assert.NotNull(createdUser);
        Assert.Equal(user.UserName, createdUser.UserName);
        Assert.Equal(user.Password, createdUser.Password);
        Assert.Equal(user.Credit, createdUser.Credit);
    }

    [Fact]
    public async void Should_Update_User()
    {
        var listUser = await _userRepository.Get(UserConstant.UpdateUserName);
        var testUser = listUser.First();

        Assert.NotNull(testUser);

        User updatedUser = UserConstant.UpdateUser(testUser);

        await _userRepository.Update(updatedUser);

        var listUserAfterUpdate = await _userRepository.Get(UserConstant.UpdateUserName);
        var result = listUserAfterUpdate.First();

        Assert.NotNull(result);
        Assert.NotEqual(testUser.Password, result.Password);
        Assert.NotEqual(testUser.Credit, result.Credit);
    }
}