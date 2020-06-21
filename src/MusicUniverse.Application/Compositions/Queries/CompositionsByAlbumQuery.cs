using AutoMapper;
using FluentValidation;
using MediatR;
using MusicUniverse.Application.Common.ViewModels;
using MusicUniverse.Application.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MusicUniverse.Application.Compositions.Queries
{
    public class CompositionsByAlbumQuery : IRequest<CompositionsListViewModel>
    {
        public int AlbumId { get; set; }
    }

    public class CompositionsByAlbumQueryHandler : IRequestHandler<CompositionsByAlbumQuery, CompositionsListViewModel>
    {
        private readonly ICompositionService _composititionService;
        private readonly IMapper _mapper;

        public CompositionsByAlbumQueryHandler(ICompositionService compositionService, IMapper mapper)
        {
            _composititionService = compositionService;
            _mapper = mapper;
        }

        public async Task<CompositionsListViewModel> Handle(CompositionsByAlbumQuery request, CancellationToken cancellationToken)
        {
            var result = await _composititionService.GetCompositionsByAlbumIdAsync(request.AlbumId);

            return new CompositionsListViewModel
            {
                Count = result.Count,
                Compositions = result.Select(c => _mapper.Map<CompositionViewModel>(c)).ToList()
            };
        }
    }

    public class CompositionsByAlbumQueyrValidator : AbstractValidator<CompositionsByAlbumQuery>
    {
        public CompositionsByAlbumQueyrValidator()
        {
            RuleFor(x => x.AlbumId).NotEqual(default(int));
        }
    }
}
