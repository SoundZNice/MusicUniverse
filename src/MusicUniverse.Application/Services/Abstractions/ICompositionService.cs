using MusicUniverse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicUniverse.Application.Services.Abstractions
{
    public interface ICompositionService
    {
        Task<IList<Composition>> GetCompositionsByArtistIdAsync(int artistId);
        Task<IList<Composition>> GetCompositionsByAlbumIdAsync(int albumId);
    }
}
