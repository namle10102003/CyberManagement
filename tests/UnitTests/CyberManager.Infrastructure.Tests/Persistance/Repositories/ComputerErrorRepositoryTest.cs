using CyberManager.Domain.Entities;
using CyberManager.Infrastructure.Persistance.DataAccess;
using CyberManager.Infrastructure.Persistance.Repositories;
using CyberManager.Infrastructure.Tests.Persistance.Repositories.Constants;

namespace CyberManager.Infrastructure.Tests.Persistance.Repositories;

public class ComputerErrorRepositoryTest
{
    private readonly DataAccess _dataAccess;
    private readonly ComputerErrorRepository _repository;

    public ComputerErrorRepositoryTest()
    {
        _dataAccess = DataAccessConstant.CreateDataAccess();
        _repository = new ComputerErrorRepository(_dataAccess);
    }

    [Fact]
    public async void Should_Create_ComputerError()
    {
        var previousList = await _repository.Get();

        ComputerError error = ComputerErrorConstant.CreateComputerError();
        await _repository.Create(error);

        var nowList = await _repository.Get();

        Assert.NotNull(previousList);
        Assert.NotNull(nowList);
        Assert.True(nowList.Count() > previousList.Count());
    }

    [Fact]
    public async Task Should_Update_ComputerError()
    {
        const int testCaseId = 1;

        var previousRecord = await _repository.GetById(testCaseId);

        ComputerError error = ComputerErrorConstant.UpdateTestCase();
        await _repository.Update(error);

        var nowRecord = await _repository.GetById(testCaseId);

        Assert.NotNull(previousRecord);
        Assert.NotNull(nowRecord);
        Assert.NotEqual(previousRecord.Description, nowRecord.Description);
    }

    [Fact]
    public async Task Should_Get_ComputerError_NotSolve()
    {
        const bool isSolveConst = false;

        var errorList = await _repository.Get(isSolve: isSolveConst);

        Assert.True(errorList.Count() > 0);
        Assert.All(errorList, error => 
        {
            Assert.False(error.IsSolve);
        });
    }
}