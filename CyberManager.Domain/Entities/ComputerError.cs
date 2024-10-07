namespace CyberManager.Domain.Entities;

public class ComputerError
{
    public int Id { get; set; }
    public int ComputerId { get; set; }
    public Devices Device { get; set; }
    public string Description { get; set; } = null!;
    public bool IsSolve { get; set; }

    public Computer Computer { get; set; } = null!;

    private ComputerError() {}

    public ComputerError(
        int id,
        int computerId,
        Devices device,
        string description,
        bool isSolve)
    {
        Id = id;
        ComputerId = computerId;
        Device = device;
        Description = description;
        IsSolve = isSolve;
    }
}

public enum Devices
{
    Monitor,
    Keyboard,
    Mouse,
    CPU
}