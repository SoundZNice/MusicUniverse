using MusicUniverse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicUniverse.Application.Repositories.Abstractions
{
    public interface IAlbumRepository
    {
        Task<bool> IsInDbAsync(int albumId);

        Task<IList<Album>> GetListByArtistIdAsync(int artistId);
    }
}
