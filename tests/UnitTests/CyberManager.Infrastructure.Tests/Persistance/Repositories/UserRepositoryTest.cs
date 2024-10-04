using CyberManager.Application.Common.Interfaces.Persistences;
using CyberManager.Domain.Entities;
using CyberManager.Infrastructure.Persistance.DataAccess;
using CyberManager.Infrastructure.Persistance.Repositories;
using CyberManager.Infrastructure.Tests.Persistance.Repositories.Constants;
using Microsoft.Identity.Client;
using Moq;

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

        var createdUser = await _userRepository.Get(user.UserName);

        Assert.NotNull(createdUser);
        Assert.Equal(user.UserName, createdUser.UserName);
        Assert.Equal(user.Password, createdUser.Password);
        Assert.Equal(user.Credit, createdUser.Credit);
    }

    [Fact]
    public async void Should_Update_User()
    {
        var testUser = await _userRepository.Get(UserConstant.UpdateUserName);

        Assert.NotNull(testUser);

        User updatedUser = UserConstant.RandomCast(testUser);

        await _userRepository.Update(updatedUser);

        var result = await _userRepository.Get(UserConstant.UpdateUserName);

        Assert.NotNull(result);
        Assert.NotEqual(testUser.Credit, result.Credit);
    }
}