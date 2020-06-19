using System;
using System.Collections.Generic;
using System.Text;

namespace MusicUniverse.Domain.Entities
{
    public class MusicGenre
    {
        public MusicGenre()
        {
            ArtistsGenres = new HashSet<ArtistsGenres>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ArtistsGenres> ArtistsGenres { get; private set; }
    }
}
