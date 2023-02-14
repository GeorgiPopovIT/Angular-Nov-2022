using GorgesMusic.Core.Models.Users;
using GorgesMusic.Data.Models;

namespace GorgesMusic.Core.Users;

public interface IUserService
{
    Task<bool> RegisterUserAsync(RegisterRequestModel model);

    string GenerateJwtToken(User user, string secret);
}
