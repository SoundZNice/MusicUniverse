using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicUniverse.Application.Common.Mappings
{
    public interface IMapFrom<T>
    {
        void Map(Profile profile);
    }
}
