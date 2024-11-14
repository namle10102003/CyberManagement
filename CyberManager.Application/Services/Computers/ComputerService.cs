using System.Runtime.InteropServices;
using CyberManager.Application.Common.Interfaces.Persistences;
using CyberManager.Domain.Entities;
using CyberManager.Domain.Errors;
using ErrorOr;

namespace CyberManager.Application.Services.Computers;

public class ComputerService : IComputerService
{
    private readonly IComputerRepository _computerRepo;

    public ComputerService(IComputerRepository computerRepo)
    {
        _computerRepo = computerRepo;
    }

    public async Task<ErrorOr<Created>> Create(Computer computer)
    {
        if (computer is null)
            return Errors.Common.NullObject;

        await _computerRepo.Create(computer);
        return Result.Created;
    }

    public async Task<ErrorOr<Deleted>> Delete(int id)
    {
        var computer = _computerRepo.GetById(id);

        if (computer is null)
            return Errors.Common.InstanceIsNotExists;

        await _computerRepo.Delete(id);
        return Result.Deleted;
    }

    public async Task<IEnumerable<Computer>> Get(
        string? name = null,
        int? costPerHour = null,
        ComputerStatus? status = null)
    {
        return await _computerRepo.Get(name, costPerHour, status);
    }

    public async Task<IEnumerable<Computer>> GetAll()
    {
        return await _computerRepo.Get();
    }

    public async Task<ErrorOr<Computer>> GetById(int id)
    {
        var computer = await _computerRepo.GetById(id);

        if (computer is null)
            return Errors.Common.InstanceIsNotExists;

        return computer;
    }

    public async Task<ErrorOr<Updated>> Update(Computer computer)
    {
        var updateComputer = await _computerRepo.GetById(computer.Id);

        if (updateComputer is null)
            return Errors.Common.InstanceIsNotExists;

        if (computer.Status == ComputerStatus.Error)
            return Errors.Computer.SetErrorManually;

        await _computerRepo.Update(computer);
        return Result.Updated;
    }
}
