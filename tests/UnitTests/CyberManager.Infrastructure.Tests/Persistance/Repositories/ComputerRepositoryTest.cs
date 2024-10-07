using CyberManager.Domain.Entities;
using CyberManager.Infrastructure.Persistance.DataAccess;
using CyberManager.Infrastructure.Persistance.Repositories;
using CyberManager.Infrastructure.Tests.Persistance.Repositories.Constants;

namespace CyberManager.Infrastructure.Tests.Persistance.Repositories;

public class ComputerRepositoryTest
{
    private readonly DataAccess _dataAccess;
    private readonly ComputerRepository _computerRepository;

    public ComputerRepositoryTest()
    {
        _dataAccess = DataAccessConstant.CreateDataAccess();
        _computerRepository = new ComputerRepository(_dataAccess);
    }

    [Fact]
    public async void Should_Create_Computer()
    {
        var previousList = await _computerRepository.Get();

        Computer computer = ComputerConstant.CreateComputer();
        await _computerRepository.Create(computer);

        var nowList = await _computerRepository.Get();

        Assert.NotNull(previousList);
        Assert.NotNull(nowList);
        Assert.True(nowList.Count() > previousList.Count());
    }

    [Fact]
    public async void Should_Update_Computer()
    {
        const int testCaseId = 1;

        var previousRecord = await _computerRepository.GetById(testCaseId);

        Computer updateComputer = ComputerConstant.UpdateTestCase();
        await _computerRepository.Update(updateComputer);

        var nowRecord = await _computerRepository.GetById(testCaseId);

        Assert.NotNull(previousRecord);
        Assert.NotNull(nowRecord);
        Assert.NotEqual(nowRecord.Name, previousRecord.Name);
    }

    [Fact]
    public async void Should_Get_Computer_By_Status()
    {
        const ComputerStatus status = ComputerStatus.Online;

        var computerList = await _computerRepository.Get(status: status);

        Assert.True(computerList.Count() > 0);
        Assert.All(computerList, computer =>
        {
            Assert.Equal(ComputerStatus.Online, computer.Status);
        });
    }
}