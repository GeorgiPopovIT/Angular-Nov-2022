using GorgesMusic.Data.Models;
using Microsoft.AspNetCore.Http;

namespace GorgesMusic.Core.Models.Songs;

public record  SongInputModel(string Name,string Genre ,string Image, IFormFile File);

