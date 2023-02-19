using GorgesMusic.Core.Validators;
using Microsoft.AspNetCore.Http;

namespace GorgesMusic.Core.Models.Songs;

public record SongInputModel(string Name, string Genre, string Image, [AllowedFileExtension(".mp3")] IFormFile SongAudio);

