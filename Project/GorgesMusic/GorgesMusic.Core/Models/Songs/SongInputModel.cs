using GorgesMusic.Core.Validators;
using GorgesMusic.Data.Models;
using Microsoft.AspNetCore.Http;

namespace GorgesMusic.Core.Models.Songs;

public record SongInputModel(string Name, Genre Genre, string Image,  IFormFile SongAudio);

