using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicUniverse.Application.Common.Interfaces;
using MusicUniverse.Application.Repositories.Abstractions;
using MusicUniverse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MusicUniverse.Application.Repositories
{
    class ImageRepository : IImageRepository
    {
        private readonly IMusicUniverseDbContext _dbContext;
        private readonly ILogger<ImageRepository> _log;

        public ImageRepository(IMusicUniverseDbContext ctx, ILogger<ImageRepository> log)
        {
            _dbContext = ctx;
            _log = log;
        }

        public Task<bool> HasNameDuplicateAsync(string name)
        {
            return _dbContext.Images.AnyAsync(i => string.Equals(i.Name, name));                
        }

        public async Task UploadAsync(string name, string format, byte[] content)
        {
            _log.LogDebug($"Adding new Image {name}:{format}");

            _dbContext.Images.Add(new Image
            {
                Name = name,
                Format = format,
                Content = content                
            });

            await _dbContext.SaveChangesAsync(CancellationToken.None);

            _log.LogDebug($"Image {name}:{format} Added!");
        }
    }
}
