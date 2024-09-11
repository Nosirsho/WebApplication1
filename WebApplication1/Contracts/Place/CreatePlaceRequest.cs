namespace WebApplication1.Contracts.Place;

public record CreatePlaceRequest(string Name, Guid PlaceCategoryId, string Description);