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
    class AlbumRepository : IAlbumRepository
    {
        private readonly IMusicUniverseDbContext _dbContext;
        private readonly ILogger<AlbumRepository> _log;

        public AlbumRepository(IMusicUniverseDbContext dbContext, ILogger<AlbumRepository> log)
        {
            _dbContext = dbContext;
            _log = log;
        }

        public async Task<IList<Album>> GetListByArtistIdAsync(int artistId)
        {
            return await _dbContext.Albums
                .Include(a => a.Artist)
                .Include(a => a.Image)
                .Where(a => a.ArtistId == artistId)
                .ToListAsync();
        }

        public Task<bool> IsInDbAsync(int albumId)
        {
            return _dbContext.Albums
                .AnyAsync(a => a.Id == albumId);
        }
    }
}
