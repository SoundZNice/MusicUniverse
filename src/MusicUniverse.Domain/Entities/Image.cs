using System;
using System.Collections.Generic;
using System.Text;

namespace MusicUniverse.Domain.Entities
{
    public class Image
    {
        public Image()
        {
            Artists = new HashSet<Artist>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Format { get; set; }
        public byte[] Content { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
}
