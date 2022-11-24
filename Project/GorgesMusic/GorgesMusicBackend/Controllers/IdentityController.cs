using GorgesMusic.Core.Models.Users;
using GorgesMusic.Core.Users;
using GorgesMusic.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GorgesMusicBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class IdentityController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IOptions<JwtSettings> _jwtSettings;
    private readonly UserManager<User> _userManager;

    public IdentityController(IUserService userService, UserManager<User> userManager, IOptions<JwtSettings> jwtSettings)
    {
        this._userService = userService;
        this._userManager = userManager;
        this._jwtSettings = jwtSettings;
    }

    public async Task<ActionResult> Register(RegisterRequestModel model)
    {
        var user = new User
        {
            UserName = model.Username,
            Email = model.Email
        };

        var result = await this._userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            return Ok();
        }

        return BadRequest(result.Errors);
    }

    public async Task<ActionResult<string>> Login(LoginRequestModel model)
    {

        var user = await this._userManager.FindByNameAsync(model.Username);
        if (user is null)
        {
            return Unauthorized();
        }

        var passwordCheck = await this._userManager.CheckPasswordAsync(user, model.Password);
        if (!passwordCheck)
        {
            return Unauthorized();
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(this._jwtSettings.Value.Secret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
               new Claim(ClaimTypes.Name, user.Id.ToString())
             }),
            Expires = DateTime.UtcNow.AddMinutes(5),
            SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha512Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);

        return jwtToken;
    }
}
