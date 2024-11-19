using FluentValidation;

namespace la_tegav.Application.UseCases.UserEntity.Commands.loginUser;

public class LoginUserValidator : AbstractValidator<LoginUserRequest>
{
    public LoginUserValidator()
    {
        RuleFor(x => x.UserName)
           .NotEmpty()
           .WithMessage("{PropertyName} is required");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");
    }
}
