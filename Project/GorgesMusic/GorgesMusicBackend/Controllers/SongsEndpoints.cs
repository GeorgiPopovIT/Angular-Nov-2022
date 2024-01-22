using GorgesMusic.Core.Models.Songs;
using GorgesMusic.Core.Songs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static GorgesMusicBackend.Infrastructure.Constants.Constants.CacheName;

namespace GorgesMusicBackend.Controllers;

public static class SongsEndpoints
{
    public static void MapSongEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/lastSongs", async (ISongService songService, IMemoryCache memoryCache, CancellationToken cancellationToken) =>
        {
            if (!memoryCache.TryGetValue(LAST_ADDED_5_SONGS, out var lastSongs))
            {
                lastSongs = await songService.GetLast5AddedSongs(cancellationToken);

                var cacheEntryOptions = new MemoryCacheEntryOptions()
               .SetAbsoluteExpiration(TimeSpan.FromSeconds(10));

                memoryCache.Set(LAST_ADDED_5_SONGS, lastSongs, cacheEntryOptions);
            }

            if (lastSongs is null)
            {
                return Results.BadRequest("There are not songs.");
            }

            return Results.Ok(lastSongs);
        });

        app.MapGet("api/{id}", async (int id, ISongService songService, CancellationToken cancellationToken) =>
        {
            var song = await songService.GetSongByIdAsync(id, cancellationToken);

            if (song is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(song);
        })
            .WithName("GetSongById");

        app.MapGet("api/", async (IMemoryCache memoryCache, ISongService songService, CancellationToken cancellationToken) =>
        {
            if (!memoryCache.TryGetValue(ALL_SONGS, out var songs))
            {
                songs = await songService.GetAllAsync(cancellationToken);

                var cacheEntryOptions = new MemoryCacheEntryOptions()
              .SetSlidingExpiration(TimeSpan.FromSeconds(10));

                memoryCache.Set(ALL_SONGS, songs, cacheEntryOptions);
            }

            if (songs is null)
            {
                return Results.BadRequest("Songs are null.");
            }

            return Results.Ok(songs);
        });

        app.MapPost("api/create", async ([FromBody] SongInputModel input, ISongService songService, CancellationToken cancellationToken) =>
        {
            var songId = 0;
            try
            {
                songId = await songService.CreateSongAsync(input, cancellationToken);

            }
            catch (Exception e)
            {

                return Results.BadRequest(e.Message);
            }

            return Results.CreatedAtRoute("GetSongById", new { id = songId }, input);
        })
            .RequireAuthorization("Administrator");

        app.MapPut("api/{id}", async (int id, SongInputModel input, ISongService songService) =>
        {
            if (input is null)
            {
                return Results.NotFound();
            }

            try
            {
                await songService.UpdateSongAsync(input);
            }
            catch (Exception)
            {
                return Results.NotFound();
            }

            return Results.Ok();
        })
            .RequireAuthorization("Administrator")
            .WithName("UpdateSong");

        app.MapDelete("api/{id}", async (int id, ISongService songService, CancellationToken cancellationToken) =>
        {
            var isDeletedSong = await songService.DeleteSongAsync(id, cancellationToken);
            if (!isDeletedSong)
            {
                return Results.NotFound();
            }

            return Results.NoContent();
        })
            .RequireAuthorization("Administrator")
            .WithName("DeleteSong");
    }
}
