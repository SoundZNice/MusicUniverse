using Microsoft.EntityFrameworkCore;
using MusicUniverse.Application.Common.Interfaces;
using MusicUniverse.Domain.Common;
using MusicUniverse.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MusicUniverse.Persistence
{
    public class MusicUniverseDbContext : DbContext, IMusicUniverseDbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtistsGenres> ArtistsGenres { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<MusicGenre> Genres { get; set; }

        public MusicUniverseDbContext(DbContextOptions<MusicUniverseDbContext> options)
            : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedOn = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MusicUniverseDbContext).Assembly);
        }
    }
}
