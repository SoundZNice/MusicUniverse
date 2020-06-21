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
    class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IArtistRepository _artistRepository;

        public AlbumService(IAlbumRepository albumRepository, IArtistRepository artistRepository)
        {
            _albumRepository = albumRepository;
            _artistRepository = artistRepository;
        }

        public async Task<IList<Album>> GetListByArtistIdAsync(int artistId)
        {
            if (!await _artistRepository.IsInDbAsync(artistId))
            {
                throw new NotFoundException();
            }

            return await _albumRepository.GetListByArtistIdAsync(artistId);
        }
    }
}
