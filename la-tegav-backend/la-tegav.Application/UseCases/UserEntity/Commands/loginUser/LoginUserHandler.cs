using la_tegav.Domain.Interfaces;
using MediatR;

namespace la_tegav.Application.UseCases.UserEntity.Commands.loginUser;

public sealed class LoginUserHandler : IRequestHandler<LoginUserRequest, string>
{
    private readonly IUserRepository _userRepository;

    public LoginUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> Handle(LoginUserRequest request, CancellationToken cancellationToken)
    {
        var validator = new LoginUserValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0)
        {
            throw new Exception(validationResult.Errors[0].ErrorMessage);
        }

        if (!request.UserName.Contains("@"))
        {
            return await _userRepository
                .LoginUserByUsername(request.UserName, request.Password);
        }

        return await _userRepository
            .LoginUserByEmail(request.UserName, request.Password);
    }
}