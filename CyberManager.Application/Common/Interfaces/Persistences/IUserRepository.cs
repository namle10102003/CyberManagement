using CyberManager.Domain.Entities;

namespace CyberManager.Application.Common.Interfaces.Persistences;

public interface IUserRepository
{
    void Create(User user);
    Task<User> Get(string userName);
    void Update(User user);
}