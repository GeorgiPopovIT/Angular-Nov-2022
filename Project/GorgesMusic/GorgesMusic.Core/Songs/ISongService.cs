using GorgesMusic.Core.Models.Songs;

namespace GorgesMusic.Core.Songs;

public interface ISongService
{
    Task<IEnumerable<SongViewModel>> GetLast5AddedSongs(CancellationToken cancellationToken);
    Task<IEnumerable<SongViewModel>> GetAllAsync(CancellationToken cancellationToken);

    Task<SongViewModel> GetSongByIdAsync(int id, CancellationToken cancellationToken);

    Task<int> CreateSongAsync(SongInputModel input, CancellationToken cancellationToken);

    Task UpdateSongAsync(SongInputModel input);

    Task<bool> DeleteSongAsync(int id, CancellationToken cancellationToken);
}
