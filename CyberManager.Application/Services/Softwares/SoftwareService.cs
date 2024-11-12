using CyberManager.Application.Common.Interfaces.Persistences;
using CyberManager.Domain.Entities;
using CyberManager.Domain.Errors;
using ErrorOr;

namespace CyberManager.Application.Services.Softwares;

public class SoftwareService : ISoftwareService
{
    private readonly ISoftwareRepository _softwareRepo;

    public SoftwareService(ISoftwareRepository softwareRepo)
    {
        _softwareRepo = softwareRepo;
    }

    public async Task<ErrorOr<Software>> Create(Software software)
    {
        if (software is null)
            return Errors.Common.NullObject;

        await _softwareRepo.Create(software);
        return software;
    }

    public async Task<ErrorOr<Deleted>> Delete(int id)
    {
        var software = await _softwareRepo.GetById(id);

        if (software is null)
            return Errors.Common.InstanceIsNotExists;

        await _softwareRepo.Delete(id);
        return Result.Deleted;
    }

    public async Task<IEnumerable<Software>> GetAll()
    {
        return await _softwareRepo.Get();
    }

    public async Task<IEnumerable<Software>> GetByName(string name)
    {
        return await _softwareRepo.Get(name);
    }

    public async Task<ErrorOr<Software>> Update(Software software)
    {
        if (software is null)
            return Errors.Common.NullObject;

        var existsSoftware = await _softwareRepo.GetById(software.Id);
        if (existsSoftware is null)
            return Errors.Common.InstanceIsNotExists;

        await _softwareRepo.Update(software);
        return software;
    }
}