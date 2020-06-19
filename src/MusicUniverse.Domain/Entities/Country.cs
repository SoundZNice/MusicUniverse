using System;
using System.Collections.Generic;
using System.Text;

namespace MusicUniverse.Domain.Entities
{
    public class Country
    {
        public Country()
        {
            Artists = new HashSet<Artist>();
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public byte[] FlagImage { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
}
