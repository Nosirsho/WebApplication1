namespace WebApplication1.Models;

public class PlaceCategoty
{
    public PlaceCategoty(string name, string description)
    {
        Name = name;
        Description = description;
        Id = new Guid();
        CreatedOn = DateTime.UtcNow;
    }
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description  { get; init; }
    public DateTime CreatedOn { get; init; } 
    
}