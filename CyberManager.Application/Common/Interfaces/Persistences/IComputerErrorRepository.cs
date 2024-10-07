using CyberManager.Domain.Entities;

namespace CyberManager.Application.Common.Interfaces.Persistences;

public interface IComputerErrorRepository
{
    Task Create(ComputerError error);
    Task<IEnumerable<ComputerError>> Get(
        int? computerId = null,
        Devices? device = null,
        bool? isSolve = null);
    Task<ComputerError> GetById(int id);
    Task Update(ComputerError error);
    Task Delete(int id);
}