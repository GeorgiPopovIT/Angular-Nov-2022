using Microsoft.AspNetCore.Http;

namespace GorgesMusic.Core.Files
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(IFormFile input);
    }
}
