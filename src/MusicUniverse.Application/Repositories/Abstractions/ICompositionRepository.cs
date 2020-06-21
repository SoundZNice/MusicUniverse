using MusicUniverse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicUniverse.Application.Repositories.Abstractions
{
    public interface ICompositionRepository
    {
        Task<IList<Composition>> GetListByArtistIdAsync(int artistId);
        Task<IList<Composition>> GetListByAlbumIdAsync(int albumId);
        Task<Composition> GetItemByIdAsync(long compositionId);
    }
}
