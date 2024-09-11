using FluentValidation;
using WebApplication1.Contracts.Place;

namespace WebApplication1.Validations;

public class PlaceValidation: AbstractValidator<CreatePlaceRequest>
{
    public PlaceValidation()
    {
        RuleFor(x=>x.Name).NotEmpty().NotNull();
        RuleFor(x=>x.PlaceCategoryId).NotEmpty().NotNull().NotEqual(Guid.Empty);
        RuleFor(x=>x.Description).NotEmpty().NotNull();
    }
}