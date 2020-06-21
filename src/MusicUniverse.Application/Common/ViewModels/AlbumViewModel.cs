using AutoMapper;
using MusicUniverse.Application.Common.Mappings;
using MusicUniverse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicUniverse.Application.Common.ViewModels
{
    public class AlbumViewModel : IMapFrom<Album>
    {
        public void Map(Profile profile)
        {
            throw new NotImplementedException();
        }
    }
}
