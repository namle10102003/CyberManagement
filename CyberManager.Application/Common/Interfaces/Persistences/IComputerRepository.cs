using CyberManager.Domain.Entities;

namespace CyberManager.Application.Common.Interfaces.Persistences;

public interface IComputerRepository
{
    Task Create(Computer computer);
    Task<IEnumerable<Computer>> Get(
        string? name = null,
        int? costPerHour = null,
        ComputerStatus? status = null);
    Task<Computer> GetById(int id);
    Task Update (Computer computer);
    Task Delete(int id);
}