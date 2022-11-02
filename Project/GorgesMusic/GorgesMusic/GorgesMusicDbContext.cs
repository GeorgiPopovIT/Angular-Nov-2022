using Microsoft.EntityFrameworkCore;

namespace GorgesMusic.Data;

public class GorgesMusicDbContext : DbContext
{
	public GorgesMusicDbContext()
	{ }

	public GorgesMusicDbContext(DbContextOptions<GorgesMusicDbContext> options)
		:base(options)
	{ }
}
