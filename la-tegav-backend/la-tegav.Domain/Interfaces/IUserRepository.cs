using la_tegav.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace la_tegav.Domain.Interfaces;

public interface IUserRepository
{
    Task<IdentityResult> CreateNewUser(User userToCreate, string password);
    Task<string> LoginUserByUsername(string userName, string password);
    Task<string> LoginUserByEmail(string email, string password);
    Task<User?> getUserByEmail(string email);
}