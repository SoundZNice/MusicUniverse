﻿using MusicUniverse.Domain.Common;
using System.Collections;
using System.Collections.Generic;

namespace MusicUniverse.Domain.Entities
{
    public class Artist : AuditableEntity
    {
        public Artist()
        {
            ArtistsGenres = new HashSet<ArtistsGenres>();
            Compositions = new HashSet<Composition>();
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public int? ImageId { get; set; }

        public string Description { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }
        public Image Image { get; set; }

        public ICollection<ArtistsGenres> ArtistsGenres { get; private set; }
        public ICollection<Composition> Compositions { get; private set; }
    }
}
