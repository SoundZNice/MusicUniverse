using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicUniverse.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicUniverse.Persistence
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMusicUniverseDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MusicUniverseDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MusicUniverseDatabase")));

            services.AddScoped<IMusicUniverseDbContext>(provider => provider.GetService<MusicUniverseDbContext>());

            return services;
        }
    }
}
