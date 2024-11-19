using Microsoft.AspNetCore.Identity;

namespace la_tegav.Domain.Entities;

public class User : IdentityUser<int>
{
    public User() : base() { }
}