namespace CyberManager.Domain.Entities;

public class Bill
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public BillType Type { get; set; } 
    public string Description { get; set; } = null!;
    public int Cash { get; set; }
    public DateTime DateTime { get; set; }

    public Bill(
        int id,
        string title,
        BillType type,
        string description,
        int cash,
        DateTime dateTime
    )
    {
        Id = id;
        Title = title;
        Type = type;
        Description = description;
        Cash = cash;
        DateTime = dateTime;
    }

    public static Bill CreateDepositBillForUser(string userName, int cash)
    {
        string title = $"Deposit for user {userName}";
        string description = $"Deposit for user: {userName}, with cash: {cash}";
        return new Bill(0, title, BillType.Deposit, description, cash, DateTime.Now);
    }
}

public enum BillType
{
    Deposit,
    Withdraw
}