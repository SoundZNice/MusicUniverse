using MusicUniverse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicUniverse.Application.Services.Abstractions
{
    public interface IAlbumService
    {
        Task<IList<Album>> GetListByArtistIdAsync(int artistId);
    }
}
