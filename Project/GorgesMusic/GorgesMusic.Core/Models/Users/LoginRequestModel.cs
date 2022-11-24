using System.ComponentModel.DataAnnotations;

namespace GorgesMusic.Core.Models.Users;

public class LoginRequestModel
{
    [Required]
    public string Username { get; init; }

    [Required]
    public string Password { get; init; }
}
