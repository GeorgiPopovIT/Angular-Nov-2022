using GorgesMusic.Core.Models.Users;
using GorgesMusic.Core.Users;
using GorgesMusic.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

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

    [HttpPost]
    [Route(nameof(Register))]
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

    [HttpPost]
    [Route(nameof(Login))]
    public async Task<ActionResult<string>> Login([FromBody]LoginRequestModel model)
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
        var token = this._userService.GenerateJwtToken(user.Id, user.UserName, this._jwtSettings.Value.Secret);

        return Ok(token);
    }
}
