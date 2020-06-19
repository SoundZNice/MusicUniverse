using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
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

            return services;
        }
    }
}
