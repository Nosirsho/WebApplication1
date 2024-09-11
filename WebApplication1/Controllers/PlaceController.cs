using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Contracts.Place;
using WebApplication1.DataAccess;
using WebApplication1.Models;

namespace WebApplication1.Controllers;
[ApiController] 
[Route("[controller]")]
public class PlaceController : ControllerBase
{
    private readonly CafeDbContext _cafeDbContext;
    private readonly IValidator<CreatePlaceRequest> _validator;

    public PlaceController(CafeDbContext cafeDbContext, IValidator<CreatePlaceRequest> validator)
    {
        _cafeDbContext = cafeDbContext;
        _validator = validator;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var places = await _cafeDbContext.Places
            .Select(p => new PlaceDto(p.Id, p.Name, p.PlaceCategoty.Name, p.Description, p.CreatedOn))
            .ToListAsync();
        return Ok(new GetPlacesResponse(places));
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody]CreatePlaceRequest request, CancellationToken ct)
    {
        ValidationResult result = await _validator.ValidateAsync(request);

        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        }

        var place = new Place(request.Name, request.PlaceCategoryId, request.Description);
        await _cafeDbContext.Places.AddAsync(place, ct);
        await _cafeDbContext.SaveChangesAsync(ct);
        return Ok();
    }
}