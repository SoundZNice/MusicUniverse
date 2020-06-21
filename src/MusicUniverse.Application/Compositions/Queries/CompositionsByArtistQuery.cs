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
    public class CompositionsByArtistQuery : IRequest<CompositionsListViewModel>
    {
        public int ArtistId { get; set; }
    }

    public class CompositionsByArtistQueyrHandler : IRequestHandler<CompositionsByArtistQuery, CompositionsListViewModel>
    {
        private readonly ICompositionService _compositionService;
        private readonly IMapper _mapper;

        public CompositionsByArtistQueyrHandler(ICompositionService compositionsService, IMapper mapper)
        {
            _compositionService = compositionsService;
            _mapper = mapper;
        }

        public async Task<CompositionsListViewModel> Handle(CompositionsByArtistQuery request, CancellationToken cancellationToken)
        {
            var result = await _compositionService.GetCompositionsByArtistIdAsync(request.ArtistId);

            return new CompositionsListViewModel
            {
                Count = result.Count,
                Compositions = result.Select(c => _mapper.Map<CompositionViewModel>(c)).ToList()
            };
        }
    }

    public class CompositionsByArtistQueryValidator : AbstractValidator<CompositionsByArtistQuery>
    {
        public CompositionsByArtistQueryValidator()
        {
            RuleFor(x => x.ArtistId).NotEqual(default(int));
        }
    }
}
