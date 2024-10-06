using CyberManager.Domain.Entities;

namespace CyberManager.Infrastructure.Tests.Persistance.Repositories.Constants;

public class BillConstant
{
    public static DateTime DateStart => new DateTime(2024, 10, 6, 9, 0, 0);
    public static DateTime DateEnd => new DateTime(2024, 10, 6, 11, 0, 0);

    public static Bill CreateBill()
    {
        return new Bill(
            id: 0,
            title: "Test Case",
            type: BillType.Deposit,
            description: "Test Case",
            cash: 1000,
            dateTime: DateTime.Now);
    }

    public static bool CheckDateTime(DateTime dateTime)
    {
        return DateStart <= dateTime && DateEnd >= dateTime;
    }
}