using MusicUniverse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicUniverse.Application.Repositories.Abstractions
{
    public interface IArtistRepository
    {
        Task<IReadOnlyCollection<Artist>> GetArtistsAsync();

        Task<int> GetArtistsCount();
    }
}
