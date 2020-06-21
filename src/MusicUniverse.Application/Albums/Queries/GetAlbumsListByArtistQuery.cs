using FluentValidation;
using MediatR;
using MusicUniverse.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MusicUniverse.Application.Albums.Queries
{
    public class GetAlbumsListByArtistQuery : IRequest<AlbumsListViewModel>
    {
        public int ArtistId { get; set; }
    }

    public class GetAlbumsListByArtistQueryHandler : IRequestHandler<GetAlbumsListByArtistQuery, AlbumsListViewModel>
    {
        public Task<AlbumsListViewModel> Handle(GetAlbumsListByArtistQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class GetAlbumsListByArtistQueryValidator : AbstractValidator<GetAlbumsListByArtistQuery>
    {
        public GetAlbumsListByArtistQueryValidator()
        {
            RuleFor(x => x.ArtistId).NotEqual(default(int));
        }
    }
}
