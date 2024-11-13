using CyberManager.Domain.Entities;
using ErrorOr;

namespace CyberManager.Application.Services.Bills;

public interface IBillService
{
    Task<ErrorOr<Created>> Create(Bill bill);
    Task<IEnumerable<Bill>> GetAll();
    Task<IEnumerable<Bill>> Get(
        BillType? type = null,
        DateTime? dateStart = null,
        DateTime? dateEnd = null);
    Task<ErrorOr<Bill>> GetById(int id);
    Task<ErrorOr<Bill>> Update(Bill bill);
    Task<ErrorOr<Deleted>> Delete(int id);
}