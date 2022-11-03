using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GorgesMusic.Data.Constants;

namespace GorgesMusic.Data.Models;

public class Playlist : BaseModel
{
    [Required]
    [Unicode(true)]
    [MaxLength(PlaylistConstants.PlayListNameMaxLength)]
    public string? Name { get; set; }

    [Required]
    public string? OwnerId { get; set; }

    public User? Owner { get; set; }

    public ICollection<Song> Songs { get; init; } = new HashSet<Song>();
}
