#nullable disable
using Microsoft.EntityFrameworkCore;

// Not necessary to have context for the model class in this context, as there's only one entity in
// the database, but will prove useful should I want to expand the solution later.
public class ArtistContext : DbContext
{
    public ArtistContext(DbContextOptions<ArtistContext> options):base(options){}

    public DbSet<PopStjerneApi.Models.Artist> Artist {get; set;} = null!;
}