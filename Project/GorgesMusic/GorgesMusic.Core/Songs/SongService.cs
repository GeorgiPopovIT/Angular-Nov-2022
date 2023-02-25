using GorgesMusic.Core.Files;
using GorgesMusic.Core.Models.Songs;
using GorgesMusic.Data;
using GorgesMusic.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GorgesMusic.Core.Songs;

public class SongService : ISongService
{
    private readonly GorgesMusicDbContext _dbContext;
    private readonly IFileService _fileService;

    public SongService(GorgesMusicDbContext dbContext, IFileService fileService)
    {
        this._dbContext = dbContext;
        this._fileService = fileService;
    }

    public async Task<int> CreateSongAsync(SongInputModel input, CancellationToken cancellationToken)
    {
        if (input is null)
        {
            throw new ArgumentNullException("Input is null.");
        }
        else if (this._dbContext.Songs.Any(s => s.Name == input.Name))
        {
            throw new ArgumentException("This song already exist.");
        }

        var cloudinaryFileUrl = await this._fileService.UploadFileAsync(input.SongAudio);

        var song = new Song
        {
            Name = input.Name,
            Genre = input.Genre,
            CardImage = input.ImageLink,
            AudioLink = cloudinaryFileUrl
        };

        await this._dbContext.Songs.AddAsync(song);
        await this._dbContext.SaveChangesAsync();

        return song.Id;
    }

    public async Task UpdateSongAsync(SongInputModel input)
    {
        var currentSong = await this._dbContext.Songs.FindAsync("");

        if (currentSong is null)
        {
            throw new ArgumentNullException("This is song is not avaliable.");
        }

        currentSong.Name = input.Name;
        //currentSong.Genre = input.Genre;

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

    public async Task<IEnumerable<SongViewModel>> GetLast5AddedSongs(CancellationToken cancellationToken)
         => await this._dbContext.Songs.Select(s => new SongViewModel
         {
             Id = s.Id,
             Name = s.Name,
             ImageLink = s.CardImage,
             AudioLink = s.AudioLink,
             CreatedOn = s.CreatedOn
         }).OrderByDescending(s => s.CreatedOn).Take(5).ToListAsync();

    public async Task<IEnumerable<SongViewModel>> GetAllAsync(CancellationToken cancellationToken)
        => await this._dbContext.Songs.Select(s => new SongViewModel
        {
            Id = s.Id,
            Name = s.Name,
            ImageLink = s.CardImage,
            AudioLink = s.AudioLink
        }).OrderBy(s => Guid.NewGuid()).ToListAsync();

    public async Task<SongViewModel> GetSongByIdAsync(int id, CancellationToken cancellationToken)
        => await this._dbContext.Songs.Select(s => new SongViewModel
        {
            Id = s.Id,
            Name = s.Name,
            AudioLink = s.AudioLink,
            ImageLink = s.CardImage
        })
        .FirstOrDefaultAsync(s => s.Id == id);
}
