using GorgesMusic.Core.Models.Songs;

namespace GorgesMusic.Core.Songs;

public interface ISongService
{
    Task<SongViewModel> GetSongByIdAsync(int id,CancellationToken cancellationToken);
}
