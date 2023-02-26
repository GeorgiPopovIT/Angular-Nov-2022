using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;

namespace GorgesMusic.Core.Files;

public class FileService : IFileService
{
    private readonly Cloudinary _cloudinary;

    public FileService(Cloudinary cloudinary)
    {
        _cloudinary = cloudinary;
    }

    public async Task<string> UploadFileAsync(IFormFile input)
    {
        using var stream = input.OpenReadStream();
       
        using (var destinationStream = new MemoryStream())
        {
            var uploadParams = new VideoUploadParams
            {
                File = new FileDescription(input.FileName, stream),
                UseFilename = true,
                UniqueFilename = false,
                Overwrite = true,
                Folder = "GorgesMusic",
                DisplayName = input.Name
            };
            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            return uploadResult.Url.ToString();
        }
    }
}
