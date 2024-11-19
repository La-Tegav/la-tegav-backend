using la_tegav.Domain.Entities;

namespace la_tegav.Domain.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}