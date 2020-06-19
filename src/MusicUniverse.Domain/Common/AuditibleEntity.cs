using System;
using System.Collections.Generic;
using System.Text;

namespace MusicUniverse.Domain.Common
{
    public class AuditableEntity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
