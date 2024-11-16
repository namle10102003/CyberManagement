using CyberManager.Domain.Entities;
using ErrorOr;

namespace CyberManager.Application.Services.ComputerErrors;

public interface IComputerErrorService
{
    Task<ErrorOr<Created>> Create(ComputerError error);
    Task<IEnumerable<ComputerError>> GetAll();
    Task<IEnumerable<ComputerError>> Get(
        int? computerId = null,
        Devices? device = null,
        bool? isSolve = null);
    Task<ErrorOr<ComputerError>> GetById(int id);
    Task<ErrorOr<Updated>> Update(ComputerError error);
    Task<ErrorOr<Deleted>> Delete(int id);
}