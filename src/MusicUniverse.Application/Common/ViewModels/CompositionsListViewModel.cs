using System;
using System.Collections.Generic;
using System.Text;

namespace MusicUniverse.Application.Common.ViewModels
{
    public class CompositionsListViewModel
    {
        public int Count { get; set; }
        public IList<CompositionViewModel> Compositions { get; set; }
    }
}
