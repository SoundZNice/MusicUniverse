using System;
using System.Collections.Generic;
using System.Text;

namespace MusicUniverse.Application.Common.ViewModels
{
    public class AlbumsListViewModel
    {
        public int Count { get; set; }
        public IList<AlbumViewModel> Albums { get; set; }
    }
}
