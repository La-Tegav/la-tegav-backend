using FluentValidation;

namespace la_tegav.Application.UseCases.ProductEntity.Commands.CreateProduct;

public class CreateProductValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(25)
            .MinimumLength(3)
            .NotEmpty();

        RuleFor(x => x.Description)
            .MaximumLength(255)
            .MinimumLength(3)
            .NotEmpty();

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .NotNull();

        RuleFor(x => x.Status)
            .NotNull();
    }
}
