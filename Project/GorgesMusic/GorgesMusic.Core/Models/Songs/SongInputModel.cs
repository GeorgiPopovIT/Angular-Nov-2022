using GorgesMusic.Data.Models;
using Microsoft.AspNetCore.Http;

namespace GorgesMusic.Core.Models.Songs;

public record SongInputModel(int Id, string Name,Genre Genre ,IFormFile File);
