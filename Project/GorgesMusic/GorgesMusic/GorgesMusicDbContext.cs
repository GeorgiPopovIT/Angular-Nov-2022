using GorgesMusic.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GorgesMusic.Data;

public class GorgesMusicDbContext : IdentityDbContext<User>
{
    public GorgesMusicDbContext()
    { }

    public GorgesMusicDbContext(DbContextOptions<GorgesMusicDbContext> options)
        : base(options)
    {}

    public DbSet<Song> Songs { get; set; }

    public DbSet<Album> Albums { get; set; }

    public DbSet<Playlist> Playlists { get; set; }

    public DbSet<Artist> Artists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost; Database=GorgesMusic; Username=postgres; Password=12345");

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Song>()
            .Property(e => e.Genre)
            .HasConversion(v => v.ToString(),
                        v => (Genre)Enum.Parse(typeof(Genre), v));


        base.OnModelCreating(modelBuilder);
    }
}
