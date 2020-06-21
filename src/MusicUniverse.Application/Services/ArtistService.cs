using MusicUniverse.Application.Repositories.Abstractions;
using MusicUniverse.Application.Services.Abstractions;
using MusicUniverse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicUniverse.Application.Services
{
    class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public Task<IReadOnlyCollection<Artist>> GetArtistsListAsync()
        {
            return _artistRepository.GetArtistsAsync();
        }

        public Task<int> GetArtstsCountAsync()
        {
            return _artistRepository.GetArtistsCountAsync();
        }
    }
}
