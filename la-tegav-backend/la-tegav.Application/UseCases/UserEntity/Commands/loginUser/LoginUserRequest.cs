#nullable disable
using MediatR;

namespace la_tegav.Application.UseCases.UserEntity.Commands.loginUser;

public sealed record LoginUserRequest : IRequest<string>
{
    public string UserName { get; set; }
    public string Password { get; set; }
}