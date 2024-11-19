#nullable disable
using la_tegav.Application.Reponses;
using MediatR;

namespace la_tegav.Application.UseCases.UserEntity.Commands.CreateUser;

public class CreateUserRequest : IRequest<BaseReponse>
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
