using System.Reflection.Metadata;
using CyberManager.Domain.Entities;

namespace CyberManager.Infrastructure.Tests.Persistance.Repositories.Constants;

public class UserConstant
{
    public static string UpdateUserName => "UpdateTestCase";
    public static User CreateUser()
    {
        return new User(0, Guid.NewGuid().ToString(), "TestPassword", 1000);
    }

    public static User RandomCast(User previousUser)
    {
        Random random = new Random();
        return new User(
            previousUser.Id,
            previousUser.UserName,
            previousUser.Password,
            previousUser.Credit + random.Next(1, 10));
    }
}