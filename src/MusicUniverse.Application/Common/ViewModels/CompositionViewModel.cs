using AutoMapper;
using MusicUniverse.Application.Common.Mappings;
using MusicUniverse.Domain.Entities;
using System;

namespace MusicUniverse.Application.Common.ViewModels
{
    public class CompositionViewModel : IMapFrom<Composition>
    {
        public long Id { get; set; }
        public string Name { get; set; }       
        public DateTime? ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Lyrics { get; set; }

        public Image Image { get; set; }
        public Artist Artist { get; set; }
        public Album Album { get; set; }

        public void Map(Profile profile)
        {
            profile.CreateMap<Composition, CompositionViewModel>()
                .ForMember(dest => dest.Artist, src => src.MapFrom(c => c.Artist))
                .ForMember(dest => dest.Image, src => src.MapFrom(c => c.Image))
                .ForMember(dest => dest.Album, src => src.MapFrom(c => c.Album));
        }
    }
}
