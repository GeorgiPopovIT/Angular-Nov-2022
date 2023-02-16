using GorgesMusic.Core.Models.Users;
using GorgesMusic.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GorgesMusic.Core.Users;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;

    public UserService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public string GenerateJwtToken(User user,string secret)
    {
        var key = Encoding.UTF8.GetBytes(secret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
               new Claim(ClaimTypes.Name, user.Id.ToString()),
             }),
            Expires = DateTime.UtcNow.AddMinutes(5),
            //Issuer = "Grp",
            //Audience = "Grp",
            SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);

        return jwtToken;
    }

    public async Task<bool> RegisterUserAsync(RegisterRequestModel model)
    {
        var user = new User
        {
            UserName = model.Username,
            Email = model.Email
        };

        var result = await this._userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            return true;
        }

        return false;
    }

}
