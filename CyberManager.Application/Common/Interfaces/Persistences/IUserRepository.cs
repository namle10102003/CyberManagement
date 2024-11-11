using CyberManager.Domain.Entities;

namespace CyberManager.Application.Common.Interfaces.Persistences;

public interface IUserRepository
{
    Task Create(User user);
    Task<User> GetById(int id);
    Task<IEnumerable<User>> Get(string? userName);
    Task Update(User user);
}