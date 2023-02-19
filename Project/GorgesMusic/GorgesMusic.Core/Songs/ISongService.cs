using GorgesMusic.Core.Models.Songs;

namespace GorgesMusic.Core.Songs;

public interface ISongService
{
    Task<IEnumerable<SongViewModel>> GetAllAsync(CancellationToken cancellationToken);

    Task<SongViewModel> GetSongByIdAsync(int id, CancellationToken cancellationToken);

    Task CreateSongAsync(SongInputModel input);

    Task UpdateSongAsync(SongInputModel input);

    Task<bool> DeleteSongAsync(int id, CancellationToken cancellationToken);
}
