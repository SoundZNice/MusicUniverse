using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MusicUniverse.Application.Repositories;
using MusicUniverse.Application.Repositories.Abstractions;
using MusicUniverse.Application.Services;
using MusicUniverse.Application.Services.Abstractions;
using MusicUniverse.Application.System.Seed;
using System.Reflection;

namespace MusicUniverse.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IDbSeedService, DbSeedService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<IArtistRepository, ArtistRepository>();

            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IImageRepository, ImageRepository>();

            return services;
        }
    }
}
