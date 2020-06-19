using MusicUniverse.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicUniverse.Application.Services.Abstractions
{
    public interface IArtistService
    {
        Task<IReadOnlyCollection<Artist>> GetArtistsListAsync();

        Task<int> GetArtstsCountAsync();
    }
}
