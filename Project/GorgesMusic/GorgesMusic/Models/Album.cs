using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GorgesMusic.Data.Constants;

namespace GorgesMusic.Data.Models;

public class Album : BaseModel
{
    [Required]
    [Unicode(true)]
    [MaxLength(AlbumConstants.AlbumNameMaxLength)]
    public string? Name { get; set; }

    public short Year { get; set; }

    public ICollection<Song> Songs { get; init; } = new HashSet<Song>();
}
