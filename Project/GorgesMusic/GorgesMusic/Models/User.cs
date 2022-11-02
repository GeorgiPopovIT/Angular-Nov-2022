
using Microsoft.AspNetCore.Identity;

namespace GorgesMusic.Data.Models;

public class User : IdentityUser
{
    public string? FullName { get; set; }
}
