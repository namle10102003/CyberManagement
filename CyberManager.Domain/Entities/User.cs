namespace CyberManager.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Password { get; set;} = null!;
    public int Credit { get; set; } 

    public User(int id, string userName, string password, int credit)
    {
        Id = id;
        UserName = userName;
        Password = password;
        Credit = credit;
    }
}