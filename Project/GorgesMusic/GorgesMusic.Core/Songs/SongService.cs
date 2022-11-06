using GorgesMusic.Core.Models.Songs;
using GorgesMusic.Data;
using Microsoft.EntityFrameworkCore;

namespace GorgesMusic.Core.Songs;

public class SongService : ISongService
{
    private readonly GorgesMusicDbContext _dbContext;

    public SongService(GorgesMusicDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<SongViewModel> GetSongByIdAsync(int id, CancellationToken cancellationToken)
        => await this._dbContext.Songs.Select(s => new SongViewModel
        {
            Id = s.Id,
            Name = s.Name
        }).FirstOrDefaultAsync(s => s.Id == id);
}
