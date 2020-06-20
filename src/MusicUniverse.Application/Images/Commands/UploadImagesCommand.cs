using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using MusicUniverse.Application.Common.Enums;
using MusicUniverse.Application.Common.Models;
using MusicUniverse.Application.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MusicUniverse.Application.Images.Commands
{
    public class UploadImagesCommand : IRequest<UploadImagesCommandResult>
    {
        public ImageDto[] Images { get; set; }
    }

    public class UploadImagesCommandResult
    {
        public UploadImageCommandResult[] Results { get; set; }
    }

    public class UploadImageCommandResult
    {
        public string Name { get; set; }
        public StatusCode StatusCode { get; set; }
        public string Status { get; set; }
    }

    public class UploadImagesCommandHandler : IRequestHandler<UploadImagesCommand, UploadImagesCommandResult>
    {
        private readonly IImageService _imageService;
        private readonly ILogger<UploadImagesCommandHandler> _log;

        public UploadImagesCommandHandler(IImageService imageService, ILogger<UploadImagesCommandHandler> log)
        {
            _imageService = imageService;
            _log = log;
        }

        public async Task<UploadImagesCommandResult> Handle(UploadImagesCommand request, CancellationToken cancellationToken)
        {      
            var statusCodes = new List<UploadImageCommandResult>();
            var result = new UploadImagesCommandResult();

            foreach (var imageCmd in request.Images)
            {
                var statusCode = await _imageService.UploadImageAsync(imageCmd);
                statusCodes.Add(new UploadImageCommandResult
                {
                    Name = imageCmd.Name,
                    Status = statusCode.ToString(),
                    StatusCode = statusCode
                });
            }

            result.Results = statusCodes.ToArray();

            return result;
        }
    }

    public class UploadImagesCommandValidator : AbstractValidator<UploadImagesCommand>
    {
        public UploadImagesCommandValidator()
        {
            RuleFor(x => x.Images).NotNull().NotEmpty();
            RuleFor(x => x.Images.Select(i => i.Format)).NotEmpty();
            RuleFor(x => x.Images.Select(i => i.Name)).NotEmpty();
            RuleFor(x => x.Images.Select(i => i.Base64Content)).NotEmpty();
        }
    }
}
