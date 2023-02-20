namespace GorgesMusic.Core.Models.Songs;

public class SongViewModel
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public DateTime CreatedOn { get; set; }

    public string? ImageLink { get; init; }

    public string? AudioLink { get; init; }

}
