using FluentValidation;
namespace la_tegav.Application.UseCases.OrderEntity.Commands.CreateOrder;

public class CreateOrderValidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderValidator()
    {
        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("O endereço é obrigatório.")
            .MaximumLength(255).WithMessage("O endereço deve ter no máximo 255 caracteres.");

        RuleFor(x => x.OrderDate)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("A data do pedido não pode estar no futuro.");

        RuleFor(x => x.DeliveryDate)
            .GreaterThan(x => x.OrderDate).WithMessage("A data de entrega deve ser posterior à data do pedido.");

        //RuleFor(x => x.OrderItem)
        //    .NotNull().WithMessage("Os itens do pedido são obrigatórios.")
        //    .SetValidator(new OrderItemValidator());
    }
}
