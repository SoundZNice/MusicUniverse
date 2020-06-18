using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MusicUniverse.Domain.Entities;

namespace MusicUniverse.Persistence
{
    public class MusicUniverseDbContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }

        public MusicUniverseDbContext(DbContextOptions<MusicUniverseDbContext> options)
            : base(options)
        {

        }
    }
}
