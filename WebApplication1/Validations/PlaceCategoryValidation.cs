using FluentValidation;
using WebApplication1.Contracts.PlaceCategory;
using WebApplication1.Models;

namespace WebApplication1.Validations;

public class PlaceCategoryValidation: AbstractValidator<CreatePlaceCategoryRequest>
{
    public PlaceCategoryValidation()
    {
        RuleFor(x=>x.Name).NotEmpty().NotNull();
        RuleFor(x=>x.Description).NotEmpty().NotNull();
    }
}