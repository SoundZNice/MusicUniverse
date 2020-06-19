using System;
using System.Collections.Generic;
using System.Text;

namespace MusicUniverse.Application.Artists.Queries
{
    public class ArtistsListViewModel
    {
        public ArtistsListViewModel()
        {
            List = new List<ArtistDto>();
        }

        public int Count { get; set; }
        public IList<ArtistDto> List { get; set; }
    }


}
