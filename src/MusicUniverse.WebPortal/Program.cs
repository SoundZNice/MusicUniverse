using log4net.Core;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MusicUniverse.Application.System.Seed;
using MusicUniverse.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MusicUniverse.WebPortal
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var musicContext = services.GetRequiredService<MusicUniverseDbContext>();
                    musicContext.Database.Migrate();

                    var seedServcie = services.GetRequiredService<IDbSeedService>();
                    await seedServcie.SeedAsync(CancellationToken.None);
                }
                catch(Exception e)
                {
                    var log = services.GetRequiredService<ILogger<Program>>();
                    log.LogError($"Db migration or seeding is failed! Message: {e.Message}, Trace: {e.StackTrace}");                  
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
