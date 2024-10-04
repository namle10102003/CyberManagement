using CyberManager.Domain.Entities;

namespace CyberManager.Application.Common.Interfaces.Persistences;

public interface ISoftwareRepository
{
    Task Create(Software software);
    Task<IEnumerable<Software>> Get();
    Task Update(Software software);
    Task Delete(int id);
}