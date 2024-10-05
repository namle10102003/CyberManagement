namespace CyberManager.Domain.Entities;

public class Software
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Path { get; set; } = null!;

    private Software() {}

    public Software(
        int id,
        string name,
        string path
    )
    {
        Id = id;
        Name = name;
        Path = path;
    }
}