namespace WebApplication1.Contracts.Place;

public record PlaceDto(Guid Id, string Name, string PlaceCategoryName, string Description, DateTime CreatedOn);