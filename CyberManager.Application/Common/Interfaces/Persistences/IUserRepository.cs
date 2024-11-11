using CyberManager.Domain.Entities;

namespace CyberManager.Application.Common.Interfaces.Persistences;

public interface IUserRepository
{
    Task Create(User user);
    Task<User> GetById(int id);
    Task<User> GetByUserName(string userName);
    Task<IEnumerable<User>> Get();
    Task Update(User user);
}