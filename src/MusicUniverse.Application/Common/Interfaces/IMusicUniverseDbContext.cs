using Microsoft.EntityFrameworkCore;
using MusicUniverse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MusicUniverse.Application.Common.Interfaces
{
    public interface IMusicUniverseDbContext
    {
        DbSet<Artist> Artists { get; set; }
        DbSet<ArtistsGenres> ArtistsGenres { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<MusicGenre> Genres { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<Composition> Compositions { get; set; }
        DbSet<Album> Albums { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
