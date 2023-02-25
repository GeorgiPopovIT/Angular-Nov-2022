using GorgesMusic.Core.Models.Songs;
using GorgesMusic.Core.Songs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static GorgesMusicBackend.Infrastructure.Constants.Constants.CacheName;

namespace GorgesMusicBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SongController : ControllerBase
{
    private readonly ISongService _songService;
    private readonly IMemoryCache _memoryCache;

    public SongController(ISongService songService, IMemoryCache memoryCache)
    {
        _songService = songService;
        this._memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
    }
    [HttpGet]
    [Route("lastSongs")]
    public async Task<ActionResult<IEnumerable<SongViewModel>>> GetLast5Songs(CancellationToken cancellationToken)
    {
        if (!this._memoryCache.TryGetValue(LAST_ADDED_5_SONGS, out var lastSongs))
        {
            lastSongs = await this._songService.GetLast5AddedSongs(cancellationToken);

            var cacheEntryOptions = new MemoryCacheEntryOptions()
           .SetAbsoluteExpiration(TimeSpan.FromSeconds(10));

            _memoryCache.Set(LAST_ADDED_5_SONGS, lastSongs, cacheEntryOptions);
        }


        if (lastSongs is null)
        {
            return BadRequest("Songs are null.");
        }

        return Ok(lastSongs);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SongViewModel>> GetSongById(int id, CancellationToken cancellationToken)
    {
        var song = await this._songService.GetSongByIdAsync(id, cancellationToken);

        if (song is null)
        {
            return NotFound();
        }

        return Ok(song);
    }

    [HttpGet]
    [ResponseCache(Duration = 60 * 5, Location = ResponseCacheLocation.None)]
    public async Task<ActionResult<IEnumerable<SongViewModel>>> GetAllSongs(CancellationToken cancellationToken)
    {
        if (!this._memoryCache.TryGetValue(ALL_SONGS, out var songs))
        {
            songs = await this._songService.GetAllAsync(cancellationToken);

            var cacheEntryOptions = new MemoryCacheEntryOptions()
          .SetSlidingExpiration(TimeSpan.FromSeconds(10));

            this._memoryCache.Set(ALL_SONGS, songs, cacheEntryOptions);
        }

        if (songs is null)
        {
            return BadRequest("Songs are null.");
        }

        return Ok(songs);
    }

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<SongInputModel>> Create([FromForm] SongInputModel input, CancellationToken cancellationToken)
    {
        var songId = 0;
        try
        {
            songId = await this._songService.CreateSongAsync(input, cancellationToken);

        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }

        return CreatedAtAction(nameof(GetSongById), new {id = songId},input);
    }

    [HttpPut("id")]
    public async Task<ActionResult> UpdateSong(int id, SongInputModel input)
    {
        if (input is null)
        {
            return NotFound();
        }

        try
        {
            await this._songService.UpdateSongAsync(input);
        }
        catch (Exception)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpDelete("id")]
    public async Task<ActionResult> DeleteSong(int id, CancellationToken cancellationToken)
    {
        var isDeletedSong = await this._songService.DeleteSongAsync(id, cancellationToken);
        if (!isDeletedSong)
        {
            return NotFound();
        }

        return NoContent();
    }
}
