using FluentValidation;

namespace la_tegav.Application.UseCases.UserEntity.Commands.CreateUser;

public class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.UserName)
        .NotEmpty().WithMessage("{PropertyName} is required")
        .MaximumLength(50)
        .MinimumLength(3)
            .WithMessage("{PropertyName} should have more than 3 characters");

        RuleFor(x => x.Email)
            .NotEmpty()
                .WithMessage("{PropertyName} is required")
            .MaximumLength(50)
            .EmailAddress()
                .WithMessage("Invalid e-mail");

        RuleFor(x => x.Password)
            .Equal(x => x.ConfirmPassword)
            .WithMessage("The passwords do not match")
            .NotEmpty();
    }
}