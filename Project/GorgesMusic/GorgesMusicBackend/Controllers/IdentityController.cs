using GorgesMusic.Core.Models.Users;
using GorgesMusic.Core.Users;
using GorgesMusic.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NuGet.Protocol;

namespace GorgesMusicBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class IdentityController : ControllerBase
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IUserService _userService;
    private readonly JwtSettings _jwtSettings;
    private readonly UserManager<User> _userManager;

    public IdentityController(IUserService userService, UserManager<User> userManager,
        IOptions<JwtSettings> jwtSettings, RoleManager<IdentityRole> roleManager)
    {
        this._userService = userService;
        this._userManager = userManager;
        this._jwtSettings = jwtSettings.Value;
        _roleManager = roleManager;
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

        var role = new IdentityRole("Viewer");

        var result = await this._userManager.CreateAsync(user, model.Password);

        if (!await this._roleManager.RoleExistsAsync("Viewer"))
        {
            await this._roleManager.CreateAsync(role);
        }

        await this._userManager.AddToRoleAsync(user, role.Name);

        if (result.Succeeded)
        {
            return Ok();
        }


        return BadRequest(result.Errors);

    }

    [HttpPost]
    [Route(nameof(Login))]
    public async Task<ActionResult<string>> Login([FromBody] LoginRequestModel model)
    {

        var user = await this._userManager.FindByNameAsync(model.Username);

        if (user is null)
        {
            return Unauthorized();
        }

        var passwordCheck = await this._userManager.CheckPasswordAsync(user, model.Password);
        if (!passwordCheck)
        {
            return Unauthorized("Wrong password");
        }
        var token = this._userService.GenerateJwtToken(user, this._jwtSettings.Secret);

        return Ok(new JwtSettings { Secret = token });
    }
}
