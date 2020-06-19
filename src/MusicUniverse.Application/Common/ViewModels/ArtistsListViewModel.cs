using System.Collections.Generic;

namespace MusicUniverse.Application.Common.ViewModels
{
    public class ArtistsListViewModel
    {
        public ArtistsListViewModel()
        {
            List = new List<ArtistViewModel>();
        }

        public int Count { get; set; }
        public IList<ArtistViewModel> List { get; set; }
    }


}
