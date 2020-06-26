using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class Authorizations
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public int? AuthorizeTypeId { get; set; }
        public bool? IsActive { get; set; }
        public long? AuthorizedBy { get; set; }
        public DateTime? AuthorizedDate { get; set; }

        public virtual AuthorizeType AuthorizeType { get; set; }
    }
}
