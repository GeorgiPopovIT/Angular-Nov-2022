using System.ComponentModel.DataAnnotations;

namespace GorgesMusic.Core.Models.Users;

public class RegisterRequestModel
{
    [Required]
    [EmailAddress(ErrorMessage ="Invalid email.")]
    public string Email { get; init; }

    [Required]
    [MaxLength(100)]
    public string Username { get; init; }

    [Required]
    [MinLength(5, ErrorMessage = "Password must be at least 5 characters.")]
    public string Password { get; init; }
}