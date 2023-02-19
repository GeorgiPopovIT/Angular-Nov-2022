using GorgesMusic.Core.Models.Songs;
using GorgesMusic.Core.Songs;
using Microsoft.AspNetCore.Mvc;

namespace GorgesMusicBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SongController : ControllerBase
{
    private readonly ISongService _songService;

    public SongController(ISongService songService)
    {
        _songService = songService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SongViewModel>> GetSong(int id, CancellationToken cancellationToken = default)
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
        var songs = await this._songService.GetAllAsync(cancellationToken);

        if (songs is null)
        {
            return BadRequest("Songs are null.");
        }

        return Ok(songs);
    }

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<SongInputModel>> Create([FromForm]SongInputModel input, CancellationToken cancellationToken)
    {
        try
        {
            await this._songService.CreateSongAsync(input);

        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }

        return null;
       // return CreatedAtAction(nameof(GetSong), new { id = input.Id });
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
