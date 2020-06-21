using MusicUniverse.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicUniverse.Domain.Entities
{
    public class Composition : AuditableEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int? ArtistId { get; set; }
        public int? AlbumId { get; set; }
        public int? ImageId { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Lyrics { get; set; }

        public Image Image { get; set; }
        public Artist Artist { get; set; }
        public Album Album { get; set; }
    }
}
