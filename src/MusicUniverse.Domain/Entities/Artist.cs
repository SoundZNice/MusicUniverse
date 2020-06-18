using MusicUniverse.Domain.Common;

namespace MusicUniverse.Domain.Entities
{
    public class Artist : AuditibleEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
