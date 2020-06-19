using AutoMapper;
using MusicUniverse.Application.Common.Mappings;
using MusicUniverse.Domain.Entities;
using System.Linq;

namespace MusicUniverse.Application.Common.ViewModels
{
    public class ArtistViewModel : IMapFrom<Artist>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string[] Genres { get; set; }

        public void Map(Profile profile)
        {
            profile.CreateMap<Artist, ArtistViewModel>()
                .ForMember(dest => dest.CountryCode, src => src.MapFrom(s => s.Country.Code))
                .ForMember(dest => dest.CountryName, src => src.MapFrom(s => s.Country.Name))
                .ForMember(dest => dest.Genres, src => src.MapFrom(s => s.ArtistsGenres.Select(ag => ag.MusicGenre.Name)));
        }
    }
}
