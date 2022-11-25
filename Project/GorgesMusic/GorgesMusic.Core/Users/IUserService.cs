using GorgesMusic.Core.Models.Users;

namespace GorgesMusic.Core.Users;

public interface IUserService
{
    Task<bool> RegisterUserAsync(RegisterRequestModel model);

    string GenerateJwtToken(string userId, string username, string secret);
}
