using CyberManager.Domain.Entities;

namespace CyberManager.Application.Common.Interfaces.Persistences;

public interface IBillRepository
{
    Task Create(Bill bill);
    Task<IEnumerable<Bill>> Get(
        BillType? type = null,
        DateOnly? dateStart = null,
        DateOnly? dateEnd = null);
    Task<Bill> GetById(int id);
    Task Update(Bill bill);
    Task Delete(Bill bill);
}