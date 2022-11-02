using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GorgesMusic.Data.Constants;

namespace GorgesMusic.Data.Models;

public class Song : BaseModel
{
    [Required]
    [Unicode(true)]
    //[MaxLength(SongConstants.SongNameMaxLength)]
    public string? Name { get; set; }

    public Genre Genre { get; set; }

    public ICollection<Artist> Artists { get; init; } = new HashSet<Artist>();

    public ICollection<Playlist> Playlists { get; init; } = new HashSet<Playlist>();
}