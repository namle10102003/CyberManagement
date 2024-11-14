using CyberManager.Domain.Entities;
using ErrorOr;

namespace CyberManager.Application.Services.Computers;

public interface IComputerService
{
    Task<ErrorOr<Created>> Create(Computer computer);
    Task<IEnumerable<Computer>> GetAll();
    Task<IEnumerable<Computer>> Get(
        string? name = null,
        int? costPerHour = null,
        ComputerStatus? status = null);
    Task<ErrorOr<Computer>> GetById(int id);
    Task<ErrorOr<Updated>> Update(Computer computer);
    Task<ErrorOr<Deleted>> Delete(int id);
}