using System;
using System.Collections.Generic;
using System.Text;

namespace MusicUniverse.Domain.Entities
{
    public class ArtistsGenres
    {
        public long Id { get; set; }
        public long ArtistId { get; set; }
        public int MusicGenreId { get; set; }

        public Artist Artist { get; set; }
        public MusicGenre MusicGenre { get; set; }
    }
}
