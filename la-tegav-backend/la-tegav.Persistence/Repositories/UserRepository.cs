using la_tegav.Domain.Entities;
using la_tegav.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private UserManager<User> _userManager;
    private SignInManager<User> _signInManager;
    private ITokenService _tokenService;

    public UserRepository(UserManager<User> userManager,
        SignInManager<User> signInManager,
        ITokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<IdentityResult> CreateNewUser(User userToCreate, string password)
    {
        return await _userManager.CreateAsync(userToCreate, password);
    }

    public async Task<User?> getUserByEmail(string email)
    {
        return await _signInManager
            .UserManager
            .Users
            .FirstOrDefaultAsync(u => u.NormalizedEmail == email.ToUpper())!;
    }

    public async Task<string> LoginUserByEmail(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null) throw new NullReferenceException($"The e-mail {email} do not exists");


        if (!await _userManager.CheckPasswordAsync(user, password))
        {
            throw new NullReferenceException("Login failed");
        }

        return _tokenService.GenerateToken(user);
    }

    public async Task<string> LoginUserByUsername(string userName, string password)
    {
        var result = await _signInManager
            .PasswordSignInAsync(userName, password, false, false);

        if (!result.Succeeded) throw new NullReferenceException("Login failed");

        var user = _signInManager
            .UserManager
            .Users
            .FirstOrDefault(u => u.NormalizedUserName == userName.ToUpper());

        return _tokenService.GenerateToken(user!);
    }
}