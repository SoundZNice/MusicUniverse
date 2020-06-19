using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Logging;
using MusicUniverse.Application.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MusicUniverse.Application.Artists.Queries
{
    public class ArtistsListQuery : IRequest<ArtistsListViewModel>
    {
    }

    public class ArtistsListQueryHandler : IRequestHandler<ArtistsListQuery, ArtistsListViewModel>
    {
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        private readonly ILogger<ArtistsListQueryHandler> _log;

        public ArtistsListQueryHandler(IArtistService artistService, IMapper mapper, ILogger<ArtistsListQueryHandler> log)
        {
            _artistService = artistService;
            _mapper = mapper;

            _log = log;
        }

        public async Task<ArtistsListViewModel> Handle(ArtistsListQuery request, CancellationToken cancellationToken)
        {
            var artists = await _artistService.GetArtistsListAsync();

            return new ArtistsListViewModel
            {
                List = artists.Select(a => _mapper.Map<ArtistDto>(a)).ToList()
            };
        }
    }
}
