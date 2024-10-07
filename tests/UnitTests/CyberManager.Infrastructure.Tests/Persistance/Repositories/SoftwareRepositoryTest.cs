using CyberManager.Domain.Entities;
using CyberManager.Infrastructure.Persistance.DataAccess;
using CyberManager.Infrastructure.Persistance.Repositories;
using CyberManager.Infrastructure.Tests.Persistance.Repositories.Constants;

namespace CyberManager.Infrastructure.Tests.Persistance.Repositories;

public class SoftwareRepositoryTest
{
    private readonly DataAccess _dataAccess;
    private readonly SoftwareRepository _softwareRepository;

    public SoftwareRepositoryTest()
    {
        _dataAccess = DataAccessConstant.CreateDataAccess();
        _softwareRepository = new SoftwareRepository(_dataAccess);
    }

    [Fact]
    public async void Should_Create_Software()
    {
        var previousList = await _softwareRepository.Get();

        Software software = SoftwareConstant.CreateSoftware();
        await _softwareRepository.Create(software);

        var nowList = await _softwareRepository.Get();

        Assert.False(nowList.Count() == 0);
        Assert.True(nowList.Count() > previousList.Count());
    }

    [Fact]
    public async void Should_Update_Software()
    {
        const int testCaseId = 1;
        var previousRecord = await _softwareRepository.GetById(testCaseId);

        Software updateSoftware = SoftwareConstant.UpdateTestCase();
        await _softwareRepository.Update(updateSoftware);

        var nowRecord = await _softwareRepository.GetById(testCaseId);

        Assert.NotNull(previousRecord);
        Assert.NotNull(nowRecord);
        Assert.NotEqual(previousRecord.Path, nowRecord.Path);
    }
}