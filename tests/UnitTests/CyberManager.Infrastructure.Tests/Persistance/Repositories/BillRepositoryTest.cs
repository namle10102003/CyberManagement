using CyberManager.Domain.Entities;
using CyberManager.Infrastructure.Persistance.DataAccess;
using CyberManager.Infrastructure.Persistance.Repositories;
using CyberManager.Infrastructure.Tests.Persistance.Repositories.Constants;

namespace CyberManager.Infrastructure.Tests.Persistance.Repositories;

public class BillrepositoryTest
{
    private readonly DataAccess _dataAccess;
    private readonly BillRepository _billRepository;

    public BillrepositoryTest()
    {
        _dataAccess = DataAccessConstant.CreateDataAccess();
        _billRepository = new BillRepository(_dataAccess);
    }

    [Fact]
    public async void Should_Create_Bill()
    {
        var previousList = await _billRepository.Get();

        Bill bill = BillConstant.CreateBill();
        await _billRepository.Create(bill);

        var nowList = await _billRepository.Get();

        Assert.False(nowList.Count() == 0);
        Assert.True(nowList.Count() > previousList.Count());
    }

    [Fact]
    public async Task Should_Get_Bill_By_DateTimeAsync()
    {
        var billList = await _billRepository.Get(
            dateStart: BillConstant.DateStart,
            dateEnd: BillConstant.DateEnd);

        Assert.NotNull(billList);
        Assert.All(billList, 
            bill => Assert.True(BillConstant.CheckDateTime(bill.DateTime))
        );
    }

    [Fact]
    public async Task Should_Get_Bill_By_BillTypeAsync()
    {
        var billList = await _billRepository.Get(type: BillType.Deposit);

        Assert.True(billList.Count() > 0);
        Assert.All(billList, 
            bill => Assert.True(bill.Type == BillType.Deposit)
        );
    }
}