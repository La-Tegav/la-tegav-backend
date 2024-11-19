using FluentValidation.Results;
using la_tegav.Application.Reponses;
using la_tegav.Domain.Entities;
using la_tegav.Domain.Interfaces;
using MediatR;

namespace la_tegav.Application.UseCases.UserEntity.Commands.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, BaseReponse>
{

    private readonly IUserRepository _userRepository;

    public CreateUserHandler(IUserRepository userRepository )
    {
        _userRepository = userRepository;
    }

    public async Task<BaseReponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        CreateUserValidator validator = new CreateUserValidator();
        ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0)
        {
            throw new Exception(validationResult.Errors[0].ErrorMessage);
        }

        User userToCreate = new User
        {
            UserName = request.UserName,
            Email = request.Email
        };

        var checkIfUserExists = await _userRepository
            .getUserByEmail(request.Email);

        if (checkIfUserExists is not null)
            throw new Exception($"The user with e-mail {request.Email} has already been taken");

        if (!CheckIfPasswordsMatch(request.Password, request.ConfirmPassword))
            throw new Exception("Passwords do not match");

        var result = await _userRepository
            .CreateNewUser(userToCreate, request.Password);

        if (!result.Succeeded)
            throw new Exception(result.Errors.FirstOrDefault()?.Description);

        return new BaseReponse
        {
            Status = 200,
            MessageDetail = $"{request.UserName} was created successfully"
        };

        throw new NotImplementedException();
    }

    internal bool CheckIfPasswordsMatch(string password, string confirmPassword)
    {
        if (!password.Equals(confirmPassword)) return false;

        return true;
    }
}
