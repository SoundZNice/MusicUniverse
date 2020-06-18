using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicUniverse.Persistence
{
    public class MusicUniverseDbContextFactory : DesignTimeDbContextFactoryBase<MusicUniverseDbContext>
    {
        protected override MusicUniverseDbContext CreateNewInstance(DbContextOptions<MusicUniverseDbContext> options)
        {
            return new MusicUniverseDbContext(options);
        }
    }
}
