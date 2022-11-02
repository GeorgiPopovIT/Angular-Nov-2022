using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GorgesMusic.Data.Constants;

namespace GorgesMusic.Data.Models;

public class Artist : BaseModel
{
    [Required]
    [Unicode(true)]
    [MaxLength(ArtistConstants.ArtistNameMaxLength)]
    public string? Name { get; set; }

    public ICollection<Song> Songs { get; init; } = new HashSet<Song>();

}
