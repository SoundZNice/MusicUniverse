using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicUniverse.Application.Common.Interfaces;
using MusicUniverse.Application.Repositories.Abstractions;
using MusicUniverse.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicUniverse.Application.Repositories
{
    class ArtistRepository : IArtistRepository
    {
        private readonly IMusicUniverseDbContext _dbContext;

        private readonly ILogger<ArtistRepository> _log;

        public ArtistRepository(IMusicUniverseDbContext ctx, ILogger<ArtistRepository> log)
        {
            _dbContext = ctx;
            _log = log;
        }

        public async Task<IReadOnlyCollection<Artist>> GetArtistsAsync()
        {
            _log.LogDebug("Retrieving artists...");

            return await _dbContext.Artists
                .Include(a => a.ArtistsGenres)
                    .ThenInclude(ag => ag.MusicGenre)
                .Include(a => a.Country)
                .Include(a => a.Image)
                .ToListAsync();
        }

        public Task<int> GetArtistsCountAsync()
        {
            _log.LogDebug("Retrieving artists count...");
            return _dbContext.Artists.CountAsync();
        }

        public Task<bool> IsInDbAsync(int artistId)
        {
            return _dbContext.Artists.AnyAsync(a => a.Id == artistId);
        }
    }
}
