using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Contracts;
using WebApplication1.DataAccess;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class PlaceCategoryController : ControllerBase
{
    private readonly CafeDbContext _dbContext;

    public PlaceCategoryController(CafeDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet]
    public async Task<ActionResult> Get([FromQuery]GetPlaceCategoryRequest request, CancellationToken ct)
    {
        var pcQuery = _dbContext.PlaceCategoties
            .Where(n => string.IsNullOrWhiteSpace(request.Search) ||
                        n.Name.ToLower().Contains(request.Search.ToLower()));
        
        Expression<Func<PlaceCategoty, object>> selectorKey = request.SortItem?.ToLower() switch
        {
            "name" => placeCategory => placeCategory.Name,
            "Description" => placeCategory => placeCategory.Description,
            "date" => placeCategory => placeCategory.CreatedOn,
            _ => placeCategory => placeCategory.Id
        };
        
        pcQuery = request?.SortItem == "desc" 
            ? pcQuery.OrderByDescending(selectorKey) 
            : pcQuery.OrderBy(selectorKey);

        var placecategoryDtos = await pcQuery
            .Select(pc=>new PlaceCategoryDto(pc.Id, pc.Name, pc.Description, pc.CreatedOn))
            .ToListAsync(ct);

        return Ok(new GetPlaceCategoryResponse(placecategoryDtos));
    }


    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreatePlaceCategoryRequest request, CancellationToken ct)
    {
        var placeCategory = new PlaceCategoty(request.Name, request.Description);
        await _dbContext.PlaceCategoties.AddAsync(placeCategory,ct);
        await _dbContext.SaveChangesAsync(ct);
        
        return Ok();
    }
}