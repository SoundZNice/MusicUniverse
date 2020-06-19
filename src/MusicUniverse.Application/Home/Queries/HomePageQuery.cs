using MediatR;
using MusicUniverse.Application.Common.ViewModels;
using MusicUniverse.Application.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MusicUniverse.Application.Home.Queries
{
    public class HomePageQuery : IRequest<HomePageViewModel>
    {
    }

    class HomePageQueryHandler : IRequestHandler<HomePageQuery, HomePageViewModel>
    {
        private readonly IArtistService _artistService;

        public HomePageQueryHandler(IArtistService artistService)
        {
            _artistService = artistService;
        }

        public async Task<HomePageViewModel> Handle(HomePageQuery request, CancellationToken cancellationToken)
        {
            return new HomePageViewModel
            {
                ArtistsCount = await _artistService.GetArtstsCountAsync()
            };
        }
    }
}
