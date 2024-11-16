using CyberManager.Domain.Entities;
using ErrorOr;

namespace CyberManager.Application.Services.Softwares;

public interface ISoftwareService
{
    Task<ErrorOr<Created>> Create(Software software); 
    Task<IEnumerable<Software>> GetAll();
    Task<IEnumerable<Software>> GetByName(string name);
    Task<ErrorOr<Updated>> Update(Software software);
    Task<ErrorOr<Deleted>> Delete(int id);
}