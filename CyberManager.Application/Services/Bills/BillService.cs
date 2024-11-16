using CyberManager.Application.Common.Interfaces.Persistences;
using CyberManager.Domain.Entities;
using CyberManager.Domain.Errors;
using ErrorOr;

namespace CyberManager.Application.Services.Bills;

public class BillService : IBillService
{
    private readonly IBillRepository _billRepo;

    public BillService(IBillRepository billRepo)
    {
        _billRepo = billRepo;
    }

    public async Task<ErrorOr<Created>> Create(Bill bill)
    {
        if (bill is null)
            return Errors.Common.NullObject;

        await _billRepo.Create(bill);
        return Result.Created;
    }

    public async Task<ErrorOr<Deleted>> Delete(int id)
    {
        var bill = await _billRepo.GetById(id);

        if (bill is null)
            return Errors.Common.InstanceIsNotExists;

        await _billRepo.Delete(id);
        return Result.Deleted;
    }

    public async Task<IEnumerable<Bill>> Get(
        BillType? type = null,
        DateTime? dateStart = null,
        DateTime? dateEnd = null)
    {
        return await _billRepo.Get(type, dateStart, dateEnd);
    }

    public async Task<IEnumerable<Bill>> GetAll()
    {
        return await _billRepo.Get();
    }

    public async Task<ErrorOr<Bill>> GetById(int id)
    {
        var bill = await _billRepo.GetById(id);

        if (bill is null)
            return Errors.Common.InstanceIsNotExists;

        return bill;
    }

    public async Task<ErrorOr<Updated>> Update(Bill bill)
    {
        var updateBill = await _billRepo.GetById(bill.Id);

        if (updateBill is null)
            return Errors.Common.InstanceIsNotExists;

        await _billRepo.Update(bill);
        return Result.Updated;
    }
}