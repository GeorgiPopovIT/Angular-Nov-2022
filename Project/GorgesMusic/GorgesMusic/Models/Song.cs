using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GorgesMusic.Data.Constants;

namespace GorgesMusic.Data.Models;

public class Song : BaseModel
{
    [Required]
    [Unicode(true)] 
    [MaxLength(SongConstants.SongNameMaxLength)]
    public string? Name { get; set; }

    public string? CardImage { get; set; }

    [Required]
    public string? AudioLink { get; set; }

    public Genre Genre { get; set; }

    public ICollection<Album> Albums { get; init; } = new HashSet<Album>();

    public ICollection<Artist> Artists { get; init; } = new HashSet<Artist>();

    public ICollection<Playlist> Playlists { get; init; } = new HashSet<Playlist>();
}