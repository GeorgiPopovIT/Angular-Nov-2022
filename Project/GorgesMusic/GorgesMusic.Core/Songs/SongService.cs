using GorgesMusic.Core.Files;
using GorgesMusic.Core.Models.Songs;
using GorgesMusic.Data;
using GorgesMusic.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GorgesMusic.Core.Songs;

public class SongService : ISongService
{
    private readonly GorgesMusicDbContext _dbContext;
    private readonly FileService _fileService;

    public SongService(GorgesMusicDbContext dbContext, FileService fileService)
    {
        this._dbContext = dbContext;
        this._fileService = fileService;
    }

    public async Task CreateSong(SongInputModel input)
    {
        if (input is null)
        {
            throw new ArgumentNullException("Input is null.");
        }

        var cloudinaryFileUrl = await this._fileService.UploadFileAsync(input.File);

        var song = new Song
        {
            Name = input.Name,
            Genre = input.Genre,
            AudioLink = cloudinaryFileUrl
        };

        await this._dbContext.Songs.AddAsync(song);
        await this._dbContext.SaveChangesAsync();
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

    public async Task<bool> DeleteSongAsync(int id, CancellationToken cancellationToken)
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
