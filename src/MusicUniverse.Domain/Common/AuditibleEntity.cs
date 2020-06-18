using System;
using System.Collections.Generic;
using System.Text;

namespace MusicUniverse.Domain.Common
{
    public class AuditibleEntity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
