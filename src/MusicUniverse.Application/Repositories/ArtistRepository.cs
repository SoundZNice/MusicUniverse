using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicUniverse.Application.Common.Interfaces;
using MusicUniverse.Application.Repositories.Abstractions;
using MusicUniverse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicUniverse.Application.Repositories
{
    class ArtistRepository : IArtistRepository
    {
        private readonly IMusicUniverseDbContext _dbContext;

        private readonly Logger<ArtistRepository> _log;

        public ArtistRepository(IMusicUniverseDbContext ctx, Logger<ArtistRepository> log)
        {
            _dbContext = ctx;
            _log = log;
        }

        public async Task<IReadOnlyCollection<Artist>> GetArtistsAsync()
        {
            return await _dbContext.Artists
                .Include(a => a.ArtistsGenres)
                .Include(a => a.Country)
                .Include(a => a.ArtistsGenres.Select(g => g.MusicGenre))
                .ToListAsync();
        }

        public Task<int> GetArtistsCount()
        {
            return _dbContext.Artists.CountAsync();
        }
    }
}
