using CyberManager.Application.Common.Interfaces.Persistences;
using CyberManager.Domain.Entities;
using CyberManager.Domain.Errors;
using ErrorOr;

namespace CyberManager.Application.Services.ComputerErrors;

public class ComputerErrorService : IComputerErrorService
{
    private readonly IComputerErrorRepository _computerErrorRepo;

    public ComputerErrorService(IComputerErrorRepository computerErrorRepo)
    {
        _computerErrorRepo = computerErrorRepo;
    }

    public async Task<ErrorOr<Created>> Create(ComputerError error)
    {
        if (error is null)
            return Errors.Common.NullObject;

        await _computerErrorRepo.Create(error);
        return Result.Created;
    }

    public async Task<ErrorOr<Deleted>> Delete(int id)
    {
        var error = await _computerErrorRepo.GetById(id);

        if (error is null)
            return Errors.Common.InstanceIsNotExists;

        await _computerErrorRepo.Delete(id);
        return Result.Deleted;
    }

    public async Task<IEnumerable<ComputerError>> Get(int? computerId = null, Devices? device = null, bool? isSolve = null)
    {
        return await _computerErrorRepo.Get(computerId, device, isSolve);
    }

    public async Task<IEnumerable<ComputerError>> GetAll()
    {
        return await _computerErrorRepo.Get();
    }

    public async Task<ErrorOr<ComputerError>> GetById(int id)
    {
        var error = await _computerErrorRepo.GetById(id);

        if (error is null)
            return Errors.Common.InstanceIsNotExists;

        return error;
    }

    public async Task<ErrorOr<Updated>> Update(ComputerError error)
    {
        var updateError = await _computerErrorRepo.GetById(error.Id);

        if (updateError is null)
            return Errors.Common.InstanceIsNotExists;

        await _computerErrorRepo.Update(error);
        return Result.Updated;
    }
}