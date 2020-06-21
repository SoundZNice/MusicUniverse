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
    class CompositionRepository : ICompositionRepository
    {
        private readonly IMusicUniverseDbContext _dbContext;

        private readonly ILogger<CompositionRepository> _log;

        public CompositionRepository(IMusicUniverseDbContext dbContext, ILogger<CompositionRepository> log)
        {
            _dbContext = dbContext;
            _log = log;
        } 

        public Task<Composition> GetItemByIdAsync(long compositionId)
        {
            return _dbContext.Compositions
                .Include(c => c.Image)
                .Include(c => c.Album)
                .Include(c => c.Artist)
                .FirstOrDefaultAsync(c => c.Id == compositionId);
        }

        public async Task<IList<Composition>> GetListByAlbumIdAsync(int albumId)
        {
            return await _dbContext.Compositions
                .Include(c => c.Image)
                .Include(c => c.Album)
                .Include(c => c.Artist)
                .Where(c => c.AlbumId == albumId)
                .ToListAsync();
        }

        public async Task<IList<Composition>> GetListByArtistIdAsync(int artistId)
        {
            return await _dbContext.Compositions
                .Include(c => c.Image)
                .Include(c => c.Album)
                .Include(c => c.Artist)
                .Where(c => c.ArtistId == artistId)
                .ToListAsync();
        }
    }
}
