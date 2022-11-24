using System.ComponentModel.DataAnnotations;

namespace GorgesMusic.Core.Models.Users;

public class RegisterInputModel
{
    [Required]
    [EmailAddress]
    public string Email { get; init; }

    [Required]
    [MaxLength(100)]
    public string Username { get; init; }

    [Required]
    public string Password { get; init; }
}