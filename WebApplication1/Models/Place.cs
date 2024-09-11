namespace WebApplication1.Models;

public class Place
{
    public Place(string name, Guid placeCategoryId, string description)
    {
        Name = name;
        PlaceCategoryId = placeCategoryId;
        Description = description;
        Id = new Guid();
        CreatedOn = DateTime.UtcNow;
    }
    public Guid Id { get; init; }
    public string Name { get; init; }
    public PlaceCategoty PlaceCategoty { get; set; }
    public Guid PlaceCategoryId { get; set; }
    public string Description  { get; init; }
    public DateTime CreatedOn { get; init; } 
}