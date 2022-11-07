using GorgesMusic.Core.Songs;
using Microsoft.AspNetCore.Mvc;

namespace GorgesMusicBackend.Controllers;

[ApiController]
[Route("/songs")]
public class Song : ControllerBase
{
    private readonly ISongService _songService;

    public Song(ISongService songService)
    {
        _songService = songService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSong(int id, CancellationToken cancellationToken)
    {
        var song = await this._songService.GetSongByIdAsync(id,cancellationToken);

        if (song is null)
        {
            return NotFound();
        }

        return Ok(song);
    }
}
