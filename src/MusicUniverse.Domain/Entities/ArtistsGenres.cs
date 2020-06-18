using System;
using System.Collections.Generic;
using System.Text;

namespace MusicUniverse.Domain.Entities
{
    public class ArtistsGenres
    {
        public long ArtistId { get; set; }
        public int MusicGenreId { get; set; }
    }
}
