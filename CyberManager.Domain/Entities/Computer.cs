namespace CyberManager.Domain.Entities;

public class Computer
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int CostPerHour { get; set; } 
    public ComputerStatus Status { get; set; }
    public List<ComputerError> Errors { get; set; } = new List<ComputerError>();

    private Computer() {}

    public Computer(
        int id,
        string name,
        int costPerHour,
        ComputerStatus status
    )
    {
        Id = id;
        Name = name;
        CostPerHour = costPerHour;
        Status = status;
    }
}

public enum ComputerStatus
{
    Online,
    Offline,
    Error
}