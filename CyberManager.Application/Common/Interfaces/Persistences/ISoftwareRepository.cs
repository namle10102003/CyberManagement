using CyberManager.Domain.Entities;

namespace CyberManager.Application.Common.Interfaces.Persistences;

public interface ISoftwareRepository
{
    void Create(Software software);
    Task<IEnumerable<Software>> Get();
    void Update(Software software);
    void Delete(int id);
}