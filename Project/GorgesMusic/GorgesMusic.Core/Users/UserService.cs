using GorgesMusic.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace GorgesMusic.Core.Users;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;

    public UserService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    //public async Task<bool> RegisterUserAsync(RegisterRequestModel model)
    //{
    //    var user = new User
    //    {
    //        UserName = model.Username,
    //        Email = model.Email
    //    };

    //    var result = await this._userManager.CreateAsync(user,model.Password);

    //    if (result.Succeeded)
    //    {
    //        return true;
    //    }

    //    return false;
    //}

}
