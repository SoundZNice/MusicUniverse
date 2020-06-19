using Microsoft.Extensions.DependencyInjection;
using MusicUniverse.Application.System.Seed;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MusicUniverse.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IDbSeedService, DbSeedService>();

            return services;
        }
    }
}
