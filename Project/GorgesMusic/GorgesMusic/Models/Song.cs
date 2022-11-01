using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GorgesMusic.Data.Models.Constants;

namespace GorgesMusic.Data.Models;

public class Song : BaseModel
{
    [Required]
    [Unicode(true)]
    //[MaxLength(SongConstants.SongNameMaxLength)]
    public string? Name { get; set; }

    public ICollection<Playlist> Playlists { get; init; } = new HashSet<Playlist>();
}