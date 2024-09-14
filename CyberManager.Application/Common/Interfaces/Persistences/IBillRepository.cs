using CyberManager.Domain.Entities;

namespace CyberManager.Application.Common.Interfaces.Persistences;

public interface IBillRepository
{
    void Create(Bill bill);
    IEnumerable<Bill> Get(
        BillType? type = null,
        DateOnly? dateStart = null,
        DateOnly? dateEnd = null);
    Bill GetById(int id);
    void Update(Bill bill);
    void Delete(Bill bill);
}