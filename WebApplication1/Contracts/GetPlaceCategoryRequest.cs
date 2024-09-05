namespace WebApplication1.Contracts;

public record GetPlaceCategoryRequest(string? Search, string? SortItem, string? SortOrder);