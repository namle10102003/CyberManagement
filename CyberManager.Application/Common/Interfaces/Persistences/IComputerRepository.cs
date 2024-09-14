using CyberManager.Domain.Entities;

namespace CyberManager.Application.Common.Interfaces.Persistences;

public interface IComputerRepository
{
    void Create(Computer computer);
    IEnumerable<Computer> Get(
        string? name = null,
        int? coustPerHour = null,
        bool? isActive = null);
    Computer GetById(int id);
    void Update (Computer computer);
    void Delete(int id);
}