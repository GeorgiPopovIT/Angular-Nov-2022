using GorgesMusic.Core.Validators;
using GorgesMusic.Data.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GorgesMusic.Core.Models.Songs;

public record SongInputModel([Required]string Name, [Required]Genre Genre,
                     [Required]string ImageLink,
                     [Required][AllowedFileExtension(".mp3", ".mp4")]
                      IFormFile SongAudio);

