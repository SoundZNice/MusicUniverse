using AutoMapper;
using MusicUniverse.Application.Common.Mappings;
using MusicUniverse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicUniverse.Application.Common.Models
{
    public class ImageDto : IMapFrom<Image>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Format { get; set; }
        public string Base64Content { get; set; }

        public void Map(Profile profile)
        {
            profile.CreateMap<Image, ImageDto>()
                .ForMember(dest => dest.Base64Content, src => src.MapFrom(i => Convert.ToBase64String(i.Content)));
        }
    }
}
