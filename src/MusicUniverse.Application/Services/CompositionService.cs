using MusicUniverse.Application.Common.Exceptions;
using MusicUniverse.Application.Repositories.Abstractions;
using MusicUniverse.Application.Services.Abstractions;
using MusicUniverse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicUniverse.Application.Services
{
    class CompositionService : ICompositionService
    {
        private readonly IArtistRepository _artistRepository;
        private readonly ICompositionRepository _compositionRepository;
        private readonly IAlbumRepository _albumRepository;

        public CompositionService(
            IArtistRepository artistRepository, 
            ICompositionRepository compositionRepository, 
            IAlbumRepository albumRepository)
        {
            _artistRepository = artistRepository;
            _compositionRepository = compositionRepository;
            _albumRepository = albumRepository;
        }

        public async Task<IList<Composition>> GetCompositionsByAlbumIdAsync(int albumId)
        {
            if (!await _albumRepository.IsInDbAsync(albumId))
            {
                throw new NotFoundException();
            }

            return await _compositionRepository.GetListByAlbumIdAsync(albumId);
        }

        public async Task<IList<Composition>> GetCompositionsByArtistIdAsync(int artistId)
        {
            if (!await _artistRepository.IsInDbAsync(artistId))
            {
                throw new NotFoundException();    
            }

            return await _compositionRepository.GetListByArtistIdAsync(artistId);
        }
    }
}
