using MusicUniverse.Domain.Common;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace MusicUniverse.Domain.Entities
{
    public class Album : AuditableEntity
    {
        public Album()
        {
            Compositions = new HashSet<Composition>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Description { get; set; }
        public int? ImageId { get; set; }
        public int? ArtistId { get; set; }

        public Image Image { get; set; }
        public Artist Artist { get; set; }

        public ICollection<Composition> Compositions { get; set; }
    }
}
