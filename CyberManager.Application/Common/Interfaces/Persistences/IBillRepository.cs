using CyberManager.Domain.Entities;

namespace CyberManager.Application.Common.Interfaces.Persistences;

public interface IBillRepository
{
    void Create(Bill bill);
    Task<IEnumerable<Bill>> Get(
        BillType? type = null,
        DateOnly? dateStart = null,
        DateOnly? dateEnd = null);
    Task<Bill> GetById(int id);
    void Update(Bill bill);
    void Delete(Bill bill);
}