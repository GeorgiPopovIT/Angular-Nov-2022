using GorgesMusic.Core.Models.Songs;
using GorgesMusic.Data;
using GorgesMusic.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GorgesMusic.Core.Songs;

public class SongService : ISongService
{
    private readonly GorgesMusicDbContext _dbContext;

    public SongService(GorgesMusicDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task CreateSong(SongInputModel input)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateSongAsync(SongInputModel input)
    {
        var currentSong = await this._dbContext.Songs.FindAsync(input.Id);

        if (currentSong is null)
        {
            throw new InvalidOperationException("This is song is not avaliable.");
        }

        currentSong.Name = input.Name;
        currentSong.Genre = input.Genre;

        await this._dbContext.SaveChangesAsync();

    }

    public async Task<bool> DeleteSongAsync(int id)
    {
        var songToRemove = this._dbContext.Songs.Find(id);

        if (songToRemove is null)
        {
            return false;
        }

        this._dbContext.Songs.Remove(songToRemove);

        await this._dbContext.SaveChangesAsync();

        return true;

    }

    public async Task<IEnumerable<SongViewModel>> GetAllAsync(CancellationToken cancellationToken)
        => await this._dbContext.Songs.Select(s => new SongViewModel
        {
            Id = s.Id,
            Name = s.Name
        }).ToListAsync();

    public async Task<SongViewModel> GetSongByIdAsync(int id, CancellationToken cancellationToken)
        => await this._dbContext.Songs.Select(s => new SongViewModel { Id = s.Id, Name = s.Name })
        .FirstOrDefaultAsync(s => s.Id == id);
}
