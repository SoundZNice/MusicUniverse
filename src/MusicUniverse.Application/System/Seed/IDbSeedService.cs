﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MusicUniverse.Application.System.Seed
{
    public interface IDbSeedService
    {
        Task SeedAsync(CancellationToken cancellationToken);
    }
}
